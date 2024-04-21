using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenerItem : MonoBehaviour
{
    private Gate gate;
    private bool playerNearby;
    private InputManager inputManager;
    private Inventory inventory;
    public Item item;

    private void Start()
    {
        gate = GetComponent<Gate>();
        inventory =FindObjectOfType<Inventory>();
        inputManager = FindObjectOfType<InputManager>();
    }

    private void Update()
    {
        if (playerNearby && inputManager.InteractInput)
        {
            if (inventory.CheckHasItem(item))
            {
                gate.OpenGate();
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
