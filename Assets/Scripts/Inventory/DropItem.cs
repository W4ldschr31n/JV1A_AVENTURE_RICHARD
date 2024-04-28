using UnityEngine;

public class DropItem : MonoBehaviour
{
    // External data
    public Item item;
    // External components
    private Inventory inventory;
    // Internal components
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }
}
