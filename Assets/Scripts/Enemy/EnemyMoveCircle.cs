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

    void Start()
    {
        directionalMovement = GetComponent<DirectionalMovement>();
        centerPosition = center.position;
    }

    private void Update()
    {
        directionalMovement.direction = Vector2.Perpendicular(centerPosition - transform.position).normalized;
    }

}