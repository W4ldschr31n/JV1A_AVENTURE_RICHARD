using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsDisplay : MonoBehaviour
{
    private Item[] items;
    [SerializeField]
    private Image[] images;
    [SerializeField]
    private Image panel;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        items = new Item[3];
        inventory = FindObjectOfType<Inventory>();
        UpdateDisplay();
    }


    private void OnEnable()
    {
        Inventory.onItemAdded += UpdateDisplay;
    }

    private void OnDisable()
    {
        Inventory.onItemAdded -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        items = inventory.GetItems();
        int nbItems = items.Length;
        // Display the items we have (up to 3)
        for (int i =0; i<nbItems; i++)
        {
            images[i].enabled = true;
            images[i].sprite = items[i].sprite;
        }
        // Hide the spots for items we don't have
        for(int i=nbItems; i<3; i++)
        {
            images[i].enabled = false;
        }
        // Show the panel only if we have items
        panel.enabled = nbItems > 0;
    }
}
