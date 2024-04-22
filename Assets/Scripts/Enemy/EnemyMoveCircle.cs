using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveCircle : MonoBehaviour
{
    // Internal components
    private DirectionalMovement directionalMovement;

    // Movement
    [SerializeField]
    private Transform center;
    private Vector3 centerPosition;
    private float radius;

    void Start()
    {
        directionalMovement = GetComponent<DirectionalMovement>();
        centerPosition = center.position;
        radius = Vector3.Distance(centerPosition, transform.position);
    }

    private void Update()
    {
        // Check if we have deviated from original circle
        if(Mathf.Abs(Vector3.Distance(centerPosition, transform.position) - radius) > 0.2f)
        {
            directionalMovement.direction = centerPosition - transform.position;
        }
        else
        {
            directionalMovement.direction = Vector2.Perpendicular(centerPosition - transform.position).normalized;
        }
    }

}