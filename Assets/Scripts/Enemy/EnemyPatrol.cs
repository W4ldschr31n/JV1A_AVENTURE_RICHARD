using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Internal components
    [SerializeField]
    private Transform patrolPoint1, patrolPoint2;
    private DirectionalMovement directionalMovement;

    // Movement
    private Vector3 currentTarget;
    private bool goTowardsFirst = true;
    
    void Start()
    {
        directionalMovement = GetComponent<DirectionalMovement>();
        currentTarget = patrolPoint1.position;
    }

    void Update()
    {
        Vector3 currentDistance = currentTarget - transform.position;
        // Move if not at target
        if (currentDistance.magnitude > 0.1f)
        {
            directionalMovement.direction = currentDistance.normalized;
        }
        else // Switch target
        {
            goTowardsFirst = !goTowardsFirst;
            currentTarget = goTowardsFirst ? patrolPoint1.position : patrolPoint2.position;
        }
    }

}
