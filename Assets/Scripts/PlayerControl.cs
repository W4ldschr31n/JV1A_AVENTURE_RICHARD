using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    // Internal components
    private Rigidbody2D rgbd;
    private Animator animator;
    private DirectionalMovement directionalMovement;
    private Inventory inventory;
    [SerializeField]
    private Transform attackSpot;

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

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        directionalMovement = GetComponent<DirectionalMovement>();
        inventory = GetComponent<Inventory>();
        health = maxHealth;
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

            if (Input.GetButtonDown("Fire2"))
            {
                AttackObole();
            }
        }
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
        Vector3 offset = new Vector3(directionalMovement.lastX, directionalMovement.lastY, 0f);
        // Diagonals don't make sense for attack directions, Y direction is favored;
        if (offset.y != 0f) {
            offset.x = 0f;
            offset.Normalize();
        }
        attackSpot.position = transform.position + offset;

    }


    private void AttackJudgement()
    {
        animator.SetTrigger("AttackJudgement");
    }

    private void AttackObole()
    {
        animator.SetTrigger("AttackObole");
        if (inventory.SpendObole())
        {
            Debug.Log("BOOM");
            Instantiate(projectilePrefab, attackSpot.position, Quaternion.identity);
        }
    }

    public void TakeHit(int damage)
    {
        if (canBeDamaged)
        {
            Debug.Log("OUILLE");
            animator.SetTrigger("Hit");
            health = Math.Max(0, health - damage);
            onPlayerTakeHit?.Invoke();
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
