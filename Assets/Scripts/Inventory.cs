using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    private int nbOboles;
    public static event Action onOboleSpent;
    // Start is called before the first frame update
    void Start()
    {
        Obole.onOboleCollected += CollectObole;
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
}
