using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private bool isTracking = false;
    public float moveSpeed;
    private Transform player;
    private Rigidbody2D rgbd;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>().transform;
        rgbd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isTracking)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            Vector3 movement = direction * moveSpeed * Time.fixedDeltaTime;
            rgbd.MovePosition(transform.position + movement);
        }
    }

    public void StartTracking()
    {
        isTracking = true;
    }

    public void StopTracking()
    {
        isTracking = false;
    }
}
