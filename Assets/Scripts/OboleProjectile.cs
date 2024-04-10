using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OboleProjectile : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgbd;
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        rgbd.AddForce(speed * transform.right, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
