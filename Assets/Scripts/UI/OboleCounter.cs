using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OboleCounter : MonoBehaviour
{
    // External component
    private Inventory inventory;
    // Internal component
    private Text textCounter;
    // Start is called before the first frame update
    void Start()
    {
        textCounter = GetComponent<Text>();
        inventory = FindObjectOfType<Inventory>();
        UpdateCounter();
    }

    private void OnEnable()
    {
        Inventory.onOboleCollected += UpdateCounter;
        Inventory.onOboleSpent += UpdateCounter;
    }

    private void OnDisable()
    {
        Inventory.onOboleCollected -= UpdateCounter;
        Inventory.onOboleSpent -= UpdateCounter;
    }

    private void UpdateCounter()
    {
        textCounter.text = "x" + inventory.GetNbOboles();
    }
}
