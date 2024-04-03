using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCircle : MonoBehaviour
{
    public float moveSpeed;
    public Transform center;
    private Vector3 centerPosition;
    private Rigidbody2D rgbd;

    void Start()
    {
        centerPosition = center.position;
        rgbd = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 direction = (centerPosition - transform.position).normalized;
        Vector3 movement = Vector2.Perpendicular(direction) * moveSpeed * Time.fixedDeltaTime;
        rgbd.MovePosition(transform.position + movement);
    }
}