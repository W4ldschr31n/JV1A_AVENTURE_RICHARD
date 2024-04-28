using UnityEngine;
using UnityEngine.Events;

public class DialogueNpc : MonoBehaviour
{
    // External data
    public Dialogue dialogue;

    // Properties
    private bool isPlayerInRange, isTalking;

    // Internal components
    private DialogueManager dialogueManager;
    private InputManager inputManager;

    // Unity event
    [SerializeField]
    UnityEvent onDialogueEnd;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if(isPlayerInRange && inputManager.InteractInput)
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueManager.EndDialogue();
            StopTalking();
        }
    }

    private void TriggerDialogue()
    {
        if (!isTalking)
        {
            dialogueManager.StartDialogue(dialogue, onDialogueEnd);
            isTalking = true;
        }
        else
        {
            dialogueManager.DisplayNextQuote();
        }
    }

    public void StopTalking()
    {
        isTalking = false;
    }
}
