using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OboleProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgbd;
    public Vector3 direction;
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rgbd.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

