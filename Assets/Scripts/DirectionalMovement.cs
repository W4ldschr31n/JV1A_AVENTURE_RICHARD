using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalMovement : MonoBehaviour
{
    // Internal component
    private Rigidbody2D rgbd;
    private Animator animator;
    // Movement
    public bool canMove = true;
    public float moveSpeed;
    [HideInInspector]
    public Vector3 direction;
    //[HideInInspector]
    public float lastX, lastY;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastY = -1f; // Force facing down at start
    }

    // Update is called once per frame
    void Update()
    {
        if (direction.magnitude == 0f || !canMove)
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
        // Movement - direction is computed in <T>.Update() for responsiveness reasons
        if (canMove)
        {
            Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;
            rgbd.MovePosition(transform.position + movement);
        }
    }
}
