using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private int nbOboles;
    public static event Action onOboleSpent;
    private SortedSet<Item> items;
    // Start is called before the first frame update
    void Start()
    {
        Obole.onOboleCollected += CollectObole;
        items = new SortedSet<Item>();
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
    }

    public SortedSet<Item> GetItems()
    {
        return items;
    }

    public bool CheckHasItem(Item item)
    {
        return items.Contains(item);
    }
}
