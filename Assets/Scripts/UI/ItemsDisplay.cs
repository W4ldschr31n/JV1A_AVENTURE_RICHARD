using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsDisplay : MonoBehaviour
{
    private Item[] items;
    [SerializeField]
    private Image[] images;
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
        for (int i =0; i<nbItems; i++)
        {
            images[i].enabled = true;
            images[i].sprite = items[i].sprite;
        }
        for(int i=nbItems; i<3; i++)
        {
            images[i].enabled = false;
        }
    }
}
