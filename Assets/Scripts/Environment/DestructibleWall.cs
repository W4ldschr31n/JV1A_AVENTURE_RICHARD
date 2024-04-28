using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    // Internal components
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void GetHit()
    {
        animator.Play("Destroy");
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
