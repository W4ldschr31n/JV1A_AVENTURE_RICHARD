using UnityEngine;

public class DetectionArea : MonoBehaviour
{
    // External component
    [SerializeField]
    private EnemyTracker enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.StartTracking();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.StopTracking();
        }
    }
}
