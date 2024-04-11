using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OboleProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgbd;
    void Start()
    {
        // Propel the projectile only once
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.AddForce(speed * transform.right, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

