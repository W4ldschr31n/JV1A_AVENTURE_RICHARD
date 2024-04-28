using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObolesDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject textOboles, imageOboles;
    private InputDisplayManager inputDisplayManager;
    void Start()
    {
        inputDisplayManager = FindObjectOfType<InputDisplayManager>();
        textOboles.SetActive(inputDisplayManager.canDisplayObole);
        imageOboles.SetActive(inputDisplayManager.canDisplayObole);
    }
}
