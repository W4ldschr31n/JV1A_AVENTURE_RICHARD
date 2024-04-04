using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OboleCounter : MonoBehaviour
{
    private Text textCounter;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        textCounter = GetComponent<Text>();
        inventory = FindObjectOfType<Inventory>();
        Obole.onOboleCollected += UpdateCounter;
        Inventory.onOboleSpent += UpdateCounter;
        UpdateCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateCounter()
    {
        textCounter.text = "x" + inventory.GetNbOboles();
    }
}
