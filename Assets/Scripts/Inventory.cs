using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Inventory : MonoBehaviour
{
    private int nbOboles;
    public static event Action onOboleSpent;
    public static event Action onItemAdded;
    private List<Item> items;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
    }

    private void OnEnable()
    {
        Obole.onOboleCollected += CollectObole;
    }

    private void OnDisable()
    {
        Obole.onOboleCollected -= CollectObole;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CollectObole()
    {
        nbOboles++;
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
        items.Add(item);
        onItemAdded?.Invoke();
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
