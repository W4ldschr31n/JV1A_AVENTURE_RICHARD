using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // Internal components
    private Rigidbody2D rgbd;
    private Collider2D playerHitbox;
    private Animator animator;
    private DirectionalMovement directionalMovement;
    private Inventory inventory;
    [SerializeField]
    private Transform attackSpot;
    [SerializeField]
    private Transform chargeTransform;

    // External components
    public GameObject projectilePrefab;
    
    // Events
    public static event Action onPlayerTakeHit;
    public static event Action onPlayerHeal;
    public static event Action onPlayerDead;

    // Health
    [SerializeField]
    private int maxHealth = 100;
    public int health;

    // Attacks
    public bool canBeDamaged = true;
    public bool canAttack = true;
    private Vector3 attackDirection;
    private bool isCharging = false;
    [SerializeField]
    private float chargeSpeed;
    [SerializeField]
    private LayerMask wallLayer;
    private float originalDrag;

    // Sounds
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] judgementAudio;


    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        playerHitbox = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        directionalMovement = GetComponent<DirectionalMovement>();
        inventory = GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
        originalDrag = rgbd.drag;
    }

    private void Update()
    {
        // Attack
        if (canAttack)
        { 
            if (Input.GetButtonDown("Fire1"))
            {
                AttackJudgement();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                AttackObole();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Alo");
                AttackCharge();
            }
        }
        // Cancel Charge ?

        // Reset
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector2.zero;
        }

        // Movement - the actual moving happens in DirectionalMovement.FixedUpdate() for consistency reasons
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        directionalMovement.direction = new Vector3(dirX, dirY).normalized;

        // Move attack spot accordingly
        attackDirection = new Vector3(directionalMovement.lastX, directionalMovement.lastY, 0f);
        // Diagonals don't make sense for attack directions, Y direction is favored;
        if (attackDirection.y != 0f) {
            attackDirection.x = 0f;
            attackDirection.Normalize();
        }
        attackSpot.position = transform.position + attackDirection;

    }


    private void AttackJudgement()
    {
        animator.SetTrigger("AttackJudgement");
    }

    public void PlayJudgementSound()
    {
        AudioClip randomClip = judgementAudio[UnityEngine.Random.Range(0, judgementAudio.Length)];
        audioSource.clip = randomClip;
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource.Stop();
    }

    private void AttackObole()
    {
        if (inventory.SpendObole())
        {
            GameObject projectile = Instantiate(projectilePrefab, attackSpot.position, Quaternion.identity);
            projectile.GetComponent<OboleProjectile>().direction = attackDirection;
            animator.SetTrigger("AttackObole");
        }
    }

    private void AttackCharge()
    {
        animator.SetTrigger("AttackCharge");
        // Force linear movement
        rgbd.velocity = Vector3.zero;
        rgbd.drag = 0;
        rgbd.AddRelativeForce(attackDirection * chargeSpeed, ForceMode2D.Impulse);
        isCharging = true;
        // Adapt the charge direction
        chargeTransform.right = attackDirection;
    }

    private void FixedUpdate()
    {
        if (isCharging)
        {
            // While charging, scan ahead for a wall
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            ContactFilter2D contactFilter = new ContactFilter2D();
            contactFilter.SetLayerMask(wallLayer);
            float scanDistance = 0.5f;
            playerHitbox.Cast(attackDirection, contactFilter, hits, scanDistance);
            // If there is wall in front of us, stop charging
            if (hits.Count > 0)
            {
                animator.SetTrigger("ChargeStun");
                isCharging = false;
                // Stop linear movement
                rgbd.drag = originalDrag;
                rgbd.velocity = Vector3.zero;
                // If we hit a destructible wall, destroy it
                foreach(RaycastHit2D hit in hits)
                {
                    if (hit.collider.gameObject.CompareTag("DestructibleWall"))
                    {
                        hit.collider.gameObject.GetComponent<DestructibleWall>().GetHit();
                    }
                }
            }
        }
    }

    public void TakeHit(int damage)
    {
        if (canBeDamaged)
        {
            animator.SetTrigger("Hit");
            // Lose health
            health = Math.Max(0, health - damage);
            onPlayerTakeHit?.Invoke();
            // Check if dead
            if (health <= 0)
            {
                Die();
            }

        }
    }

    public void TakeFaith()
    {
        animator.SetTrigger("Heal");
        health = Math.Min(maxHealth, health + GameData.FAITH_HEAL);
        onPlayerHeal?.Invoke();
    }

    public void Die()
    {
        onPlayerDead?.Invoke();
        animator.SetTrigger("Dead");
    }

    public bool IsFullLife()
    {
        return health == maxHealth;
    }

}
