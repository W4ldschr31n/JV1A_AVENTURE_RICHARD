using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GetHit()
    {
        animator.Play("Destroy");
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
