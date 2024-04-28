using UnityEngine;

public class InventoryObolesDisplay : MonoBehaviour
{
    // External Components
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
