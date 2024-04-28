using UnityEngine;

public class Bridge : MonoBehaviour
{
    // External components
    [SerializeField]
    private GameObject bridgeBroken, bridgeRepaired;
    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        // If we don't have the seal, the bridge is broken
        bridgeBroken.SetActive(!inventory.hasFirstSeal);
        bridgeRepaired.SetActive(inventory.hasFirstSeal);
    }
}
