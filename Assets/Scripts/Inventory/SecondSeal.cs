using UnityEngine;

public class SecondSeal : MonoBehaviour
{
    // External components
    public GameObject portalToSpawn;
    private Inventory inventory;
    [SerializeField]
    private InteractionSecondSeal interactionSecondSeal;


    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactionSecondSeal.TriggerDialogue();
        portalToSpawn.SetActive(true);
        inventory.hasSecondSeal = true;
        Destroy(gameObject);
    }
}
