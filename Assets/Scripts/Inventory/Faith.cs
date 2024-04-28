using UnityEngine;

public class Faith : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Heal the player if he is not full life
        if (
            collision.gameObject.CompareTag("Player")
            &&
            !collision.gameObject.GetComponent<PlayerControl>().IsFullLife()
        )
        {
            collision.gameObject.GetComponent<PlayerControl>().TakeFaith();
            Destroy(gameObject);
        }
    }
}
