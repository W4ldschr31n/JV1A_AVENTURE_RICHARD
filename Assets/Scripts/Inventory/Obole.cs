using UnityEngine;

public class Obole : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Inventory>().CollectObole();
            Destroy(gameObject);
        }
    }
}
