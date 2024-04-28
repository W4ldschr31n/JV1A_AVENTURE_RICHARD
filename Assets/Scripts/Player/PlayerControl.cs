using System.Collections.Generic;
using UnityEngine;
using System;

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
    // Sounds
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] judgementAudio;

    // External components
    public GameObject projectilePrefab;
    private GameData gameData;
    private InputManager inputManager;
    
    // Events
    public static event Action onPlayerTakeHit;
    public static event Action onPlayerHeal;
    public static event Action onPlayerDead;

    // Health
    [SerializeField]
    private int maxHealth = 100;
    public int health;

    // Attacks
    public bool canJudgement;
    public bool canObole;
    public bool canCharge;
    public bool canBeDamaged;
    public bool canAttack;
    private Vector3 attackDirection;
    private bool isCharging;
    [SerializeField]
    private float chargeSpeed;
    [SerializeField]
    private LayerMask wallLayer;
    private float originalDrag;



    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        playerHitbox = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        directionalMovement = GetComponent<DirectionalMovement>();
        inventory = GetComponent<Inventory>();
        audioSource = GetComponent<AudioSource>();
        gameData = FindObjectOfType<GameData>();
        inputManager = FindObjectOfType<InputManager>();
        health = maxHealth;
        originalDrag = rgbd.drag;
    }

    private void Update()
    {
        // Inventory
        if (inputManager.ToggleInventoryInput)
        {
            gameData.ToggleInventory();
        }
        // Restrict actions when inventory is open
        if (gameData.isInventoryOpen)
        {
            return;
        }

        // Attack
        if (canAttack)
        { 
            if (inputManager.AttackJudgementInput && canJudgement)
            {
                AttackJudgement();
            }
            else if (inputManager.AttackOboleInput && canObole)
            {
                AttackObole();
            }
            else if (inputManager.AttackChargeInput && canCharge)
            {
                AttackCharge();
            }
        }

        // Movement - the actual moving happens in DirectionalMovement.FixedUpdate() for consistency reasons
        directionalMovement.direction = (Vector3)(inputManager.MoveInput).normalized;

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
        // See animation "PlayerAttackJudgement" for behaviour
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
            projectile.GetComponent<Rigidbody2D>().angularVelocity = -360f;
            projectile.GetComponent<OboleProjectile>().direction = attackDirection;
            // See animation "PlayerAttackBoloe" for behaviour
            animator.SetTrigger("AttackObole");
        }
    }

    private void AttackCharge()
    {
        // See animation "PlayerAttackCharge" for behaviour
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
                // See animation "PlayerAttackChargeStun" for behaviour
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
            // Lose health
            health = Math.Max(0, health - damage);
            onPlayerTakeHit?.Invoke();
            // Check if dead
            if (health <= 0)
            {
                Die();
            }
            else
            {
                animator.SetTrigger("Hit");
            }

        }
    }

    public void TakeFaith()
    {
        health = Math.Min(maxHealth, health + GameData.FAITH_HEAL);
        onPlayerHeal?.Invoke();
    }

    public void Die()
    {
        rgbd.simulated = false;
        onPlayerDead?.Invoke();
        animator.SetTrigger("Die");
    }

    public void Resurrect()
    {
        rgbd.simulated = true;
        health = maxHealth;
        onPlayerHeal?.Invoke();
        animator.SetTrigger("Resurrect");
    }

    public bool IsFullLife()
    {
        return health == maxHealth;
    }

}
