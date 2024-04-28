using UnityEngine;

public class DropAbility : MonoBehaviour
{
    // External data
    [SerializeField]
    private AbilityUnlock abilityUnlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            abilityUnlock.Unlock();
            Destroy(gameObject);
        }
    }
}
