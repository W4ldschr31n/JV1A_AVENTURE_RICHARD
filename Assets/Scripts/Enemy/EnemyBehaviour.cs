using UnityEngine;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    //Events
    public static event Action<Vector2, KillMethod> onEnemyKilled;

    // Properties
    public int damage;

    // Internal components
    private Animator animator;
    private Rigidbody2D rgbd;

    void Start()
    {
        animator = GetComponent<Animator>();
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControl>().TakeHit(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Judgement"))
        {
            onEnemyKilled?.Invoke(transform.position, KillMethod.Judgement);
            animator.SetTrigger("DieJudgement");
            rgbd.simulated = false;
        }
        else if (collision.gameObject.CompareTag("OboleProjectile"))
        {
            onEnemyKilled?.Invoke(transform.position, KillMethod.Obole);
            animator.SetTrigger("DieObole");
            rgbd.simulated = false;
        }
        else if (collision.gameObject.CompareTag("Charge"))
        {
            onEnemyKilled?.Invoke(transform.position, KillMethod.Charge);
            animator.SetTrigger("DieCharge");
            rgbd.simulated = false;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}


public enum KillMethod // Helps to decide what reward to drop
{
    Judgement,
    Obole,
    Charge,
}