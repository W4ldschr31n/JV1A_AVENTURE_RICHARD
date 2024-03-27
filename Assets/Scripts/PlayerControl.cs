using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rgbd;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        
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

}
