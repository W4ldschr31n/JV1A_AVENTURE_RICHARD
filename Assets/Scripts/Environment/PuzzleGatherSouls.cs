using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleGatherSouls : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool isPlayerInRange, isComplete;
    private InputManager inputManager;
    private bool isTalking;
    [SerializeField]
    UnityEvent onDialogueEnd;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inputManager = FindObjectOfType<InputManager>();
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
            dialogueManager.DisplaySimpleMessage("Les âmes damnées que vous avez libérées vous remercient. Le calice est désormais rempli, le passage s'ouvre.", onDialogueEnd);
            isComplete = true;
        }
        else
        {
            string plural = nbSoulsRemaining > 1 ? "s" : "";
            dialogueManager.DisplaySimpleMessage($"Un imposant calice bloque le passage. Vous entendez encore les lamentations de {nbSoulsRemaining} groupe{plural} d'âmes damnées à libérer.", onDialogueEnd);
        }
    }

    public void StopTalking()
    {
        isTalking = false;
        if (isComplete)
        {
            Destroy(gameObject);
        }
    }
}
