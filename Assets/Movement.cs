using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float moveSpeed;
    public Vector2 spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rgbd.AddForce(new Vector2(x * moveSpeed, 0));

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = Vector2.zero;
        }
    }

    public void Respawn()
    {
        transform.position = spawnPoint;
        rgbd.velocity = Vector2.zero;
    }
}
