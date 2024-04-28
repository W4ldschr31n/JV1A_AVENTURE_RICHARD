using UnityEngine;

public class GateOpenerItem : MonoBehaviour
{
    // External components
    private Gate gate;
    private Interactable interactable;

    // External components
    private Inventory inventory;
    private InputManager inputManager;

    // External data
    public Item item;

    // Properties
    private bool playerNearby;

    private void Start()
    {
        gate = GetComponent<Gate>();
        interactable = GetComponent<Interactable>();
        inventory = FindObjectOfType<Inventory>();
        inputManager = FindObjectOfType<InputManager>();
    }

    private void Update()
    {
        if (playerNearby && inputManager.InteractInput)
        {
            if (inventory.CheckHasItem(item))
            {
                gate.OpenGate();
                interactable.DisableSelf();
                this.enabled = false;
            }
            else
            {
                gate.DisplayMessage($"Il vous faut l'objet {item.itemName} pour ouvrir la porte.");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = false;
            gate.HideMessage();
        }
    }
}
