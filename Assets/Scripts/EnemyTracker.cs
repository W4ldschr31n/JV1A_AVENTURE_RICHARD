using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    // Internal components
    [SerializeField]
    private Transform baseSpot;
    private DirectionalMovement directionalMovement;

    // Global components
    private Vector3 basePosition;

    // Movement
    private bool isTracking = false;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        directionalMovement = GetComponent<DirectionalMovement>();
        player = FindObjectOfType<PlayerControl>().transform;
        basePosition = baseSpot.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPosition = isTracking ? player.position : basePosition;
        // Avoid stuttering on a spot by checking if movement is really necessary
        if(Vector3.Distance(targetPosition, transform.position) > 0.1f)
        {
            directionalMovement.direction = (targetPosition - transform.position).normalized;
        }
        else
        {
            directionalMovement.direction = Vector3.zero;
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
