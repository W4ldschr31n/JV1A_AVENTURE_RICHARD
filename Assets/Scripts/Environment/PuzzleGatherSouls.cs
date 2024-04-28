using UnityEngine;
using UnityEngine.Events;

public class PuzzleGatherSouls : MonoBehaviour
{
    // Internal components
    private Interactable interactable;
    // External components
    private DialogueManager dialogueManager;
    private InputManager inputManager;

    // Properties
    private bool isPlayerInRange, isComplete;
    private bool isTalking;

    // Unity event
    [SerializeField]
    UnityEvent onDialogueEnd;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inputManager = FindObjectOfType<InputManager>();
        interactable = GetComponent<Interactable>();
    }

    void Update()
    {
        if (isPlayerInRange && inputManager.InteractInput)
        {
            if (!isTalking)
            {
                TriggerDialogue();
                isTalking = true;
            }
            else
            {
                dialogueManager.DisplayNextQuote();
            }
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
        }
    }

    private void TriggerDialogue()
    {
        int nbSoulsRemaining = GameObject.FindGameObjectsWithTag("LostSoul").Length;
        if (nbSoulsRemaining == 0)
        {
            dialogueManager.DisplaySimpleMessage("Les �mes damn�es que vous avez lib�r�es vous remercient. Le calice est d�sormais rempli, le passage s'ouvre.", onDialogueEnd);
            isComplete = true;
        }
        else
        {
            string plural = nbSoulsRemaining > 1 ? "s" : "";
            dialogueManager.DisplaySimpleMessage($"Un imposant calice bloque le passage. Vous entendez encore les lamentations de {nbSoulsRemaining} groupe{plural} d'�mes damn�es � lib�rer.", onDialogueEnd);
        }
    }

    public void StopTalking()
    {
        isTalking = false;
        if (isComplete)
        {
            interactable.DisableSelf();
            Destroy(gameObject);
        }
    }
}
