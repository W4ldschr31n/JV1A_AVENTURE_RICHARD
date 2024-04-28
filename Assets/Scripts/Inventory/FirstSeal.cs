using UnityEngine;

public class FirstSeal : MonoBehaviour
{
    // External components
    public DialogueNpc dialogueNpcToReplace;
    public Dialogue dialogueToReplace;
    private Inventory inventory;
    [SerializeField]
    private InteractionFirstSeal interactionFirstSeal;


    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactionFirstSeal.TriggerDialogue();
        dialogueNpcToReplace.dialogue = dialogueToReplace;
        inventory.hasFirstSeal = true;
        Destroy(gameObject);
    }
}
