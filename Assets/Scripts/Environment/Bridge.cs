using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField]
    private GameObject bridgeBroken, bridgeRepaired;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        // If we don't have the seal, the bridge is broken
        bridgeBroken.SetActive(!inventory.hasFirstSeal);
        bridgeRepaired.SetActive(inventory.hasFirstSeal);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
