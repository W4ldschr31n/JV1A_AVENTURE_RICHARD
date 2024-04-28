using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Inventory : MonoBehaviour
{
    // Properties
    private int nbOboles;
    public bool hasFirstSeal;
    public bool hasSecondSeal;
    private List<Item> items;
    // Events
    public static event Action onOboleCollected;
    public static event Action onOboleSpent;
    public static event Action onItemAdded;

    void Start()
    {
        items = new List<Item>();
    }

    public void CollectObole()
    {
        nbOboles++;
        onOboleCollected?.Invoke();
    }

    public int GetNbOboles()
    {
        return nbOboles;
    }

    public bool SpendObole() {
        if(nbOboles > 0)
        {
            nbOboles--;
            onOboleSpent?.Invoke();
            return true;
        }
        return false;
    }

    public void AddItem(Item item)
    {
        if(items.Count < 3 && !items.Contains(item))
        {
            items.Add(item);
            onItemAdded?.Invoke();
        }
        // else: not supposed to happen  ¯\_()_/¯
    }

    public Item[] GetItems()
    {
        // If not yet initialized
        if(items == null)
        {
            return new Item[0];
        }
        return items.ToArray<Item>(); // Requires System.Linq
    }

    public bool CheckHasItem(Item item)
    {
        return items.Contains(item);
    }
}
