using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private bool isTracking = false;
    public float moveSpeed;
    private Transform player;
    private Rigidbody2D rgbd;
    [SerializeField]
    private Transform baseSpot;
    private Vector3 basePosition;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControl>().transform;
        rgbd = GetComponent<Rigidbody2D>();
        basePosition = baseSpot.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition, direction, movement;
        targetPosition = isTracking ? player.position : basePosition;
        // Avoid stuttering on a spot by checking movement is really necessary
        if(Vector3.Distance(targetPosition, transform.position) > 0.1f)
        {
            direction = (targetPosition - transform.position).normalized;
            movement = direction * moveSpeed * Time.fixedDeltaTime;
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
