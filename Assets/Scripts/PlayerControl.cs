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
    private Inventory inventory;
    // Events
    public static event Action onPlayerTakeHit;
    public static event Action onPlayerHeal;
    public static event Action onPlayerDead;
    // Movement
    public float moveSpeed;
    private Vector3 direction;
    private float lastX, lastY;
    // Health
    [SerializeField]
    private int maxHealth = 100;
    public int health;
    // State
    public bool canBeDamaged = true;
    public bool canAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inventory = FindObjectOfType<Inventory>();
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
                ThrowObole();
            }
        }
        // Reset
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector2.zero;
        }

        // Movement - the actual moving happens in FixedUpdate() for consistency reasons
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");
        direction = new Vector3(dirX, dirY).normalized;

        // Animation
        UpdateAnimation();

    }

    private void UpdateAnimation()
    {
        if (direction.magnitude == 0f)
        { // Not moving
            animator.SetFloat("LastDirX", lastX);
            animator.SetFloat("LastDirY", lastY);
            animator.SetBool("Movement", false);
        }
        else
        { // Moving
            lastX = direction.x;
            lastY = direction.y;
            animator.SetBool("Movement", true);
        }
        // Keep track of the faced direction
        animator.SetFloat("DirX", direction.x);
        animator.SetFloat("DirY", direction.y);
    }

    void FixedUpdate()
    {
        // Movement - direction is computed in Update() for responsiveness reasons
        Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;
        rgbd.MovePosition(transform.position + movement);
    }

    private void AttackJudgement()
    {
        animator.Play("JudgementAnimation");
    }

    private void ThrowObole()
    {
        if(inventory.SpendObole())
        {
            Debug.Log("BOOM");
        }
    }

    public void TakeHit(int damage)
    {
        if (canBeDamaged)
        {
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
