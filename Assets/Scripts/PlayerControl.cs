using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private Animator animator;
    private Inventory inventory;
    public float moveSpeed;
    private int maxHealth = 100;
    public int health;
    public static event Action onPlayerTakeHit;
    public static event Action onPlayerHeal;
    public static event Action onPlayerDead;
    private bool canBeDamaged = true;
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
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowObole();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, y).normalized;
        Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;
        rgbd.MovePosition(transform.position + movement);

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector2.zero;
        }
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
            onPlayerTakeHit?.Invoke();
            animator.SetTrigger("Hit");
            health = Math.Max(0, health - damage);
            if (health <= 0)
            {
                Die();
            }

        }
    }

    public void Die()
    {
        onPlayerDead?.Invoke();
        animator.SetTrigger("Dead");
    }

}
