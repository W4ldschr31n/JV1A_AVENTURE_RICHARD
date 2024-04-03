using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rgbd;
    [SerializeField]
    private Transform patrolPoint1, patrolPoint2;
    private Vector3 currentTarget;
    private bool goTowardsFirst = true;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTarget = patrolPoint1.position;
        rgbd = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Move if not at target
        if (Vector2.Distance(transform.position, currentTarget) > 0.1f)
        {
            rgbd.MovePosition(Vector2.MoveTowards(transform.position, currentTarget, speed * Time.fixedDeltaTime));
        }
        else // Switch target
        {
            goTowardsFirst = !goTowardsFirst;
            currentTarget = goTowardsFirst ? patrolPoint1.position : patrolPoint2.position;
        }
    }

}
