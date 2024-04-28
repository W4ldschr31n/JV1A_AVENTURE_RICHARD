using UnityEngine;
using UnityEngine.Events;

public class InteractionFirstSeal : MonoBehaviour
{
    // External components
    private DialogueManager dialogueManager;
    private InputManager inputManager;
    // Properties
    private bool isEnabled;
    // Unity event
    public UnityEvent onDialogueEnd;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if(isEnabled && inputManager.InteractInput)
        {
            dialogueManager.DisplayNextQuote();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueManager.EndDialogue();
        }
    }

    public void TriggerDialogue()
    {
        isEnabled = true;
        dialogueManager.DisplaySimpleMessage("Vous trouvez le <b>sceau de la justice</b>. Re tournez voir <b>Mère</b>.");
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
