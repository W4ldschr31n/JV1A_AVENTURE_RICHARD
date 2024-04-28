using UnityEngine;

public class OboleProjectile : MonoBehaviour
{
    // Internal component
    private Rigidbody2D rgbd;
    // Properties
    public float speed;
    public Vector3 direction;

    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rgbd.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

