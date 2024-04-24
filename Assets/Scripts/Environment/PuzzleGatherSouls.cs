using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGatherSouls : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private bool isPlayerInRange, isComplete;
    private InputManager inputManager;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inputManager = FindObjectOfType<InputManager>();
    }

    void Update()
    {
        if (isPlayerInRange && inputManager.InteractInput)
        {
            if(!isComplete)
            {
                TriggerDialogue();
            }
            else
            {
                DestroySelf();
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
            if (!isComplete)
            {
                isPlayerInRange = false;
                dialogueManager.EndDialogue();
            }
            else
            {
                DestroySelf();
            }
        }
    }

    private void TriggerDialogue()
    {
        int nbSoulsRemaining = GameObject.FindGameObjectsWithTag("LostSoul").Length;
        if (nbSoulsRemaining == 0)
        {
            dialogueManager.DisplaySimpleMessage("Les âmes damnées que vous avez libérées vous remercient. Le calice est désormais rempli, le passage s'ouvre.");
            isComplete = true;
        }
        else
        {
            string plural = nbSoulsRemaining > 1 ? "s" : "";
            dialogueManager.DisplaySimpleMessage($"Un imposant calice bloque le passage. Vous entendez encore les lamentations de {nbSoulsRemaining} groupe{plural} d'âmes damnées à libérer.");
        }
    }

    private void DestroySelf()
    {
        dialogueManager.EndDialogue();
        Destroy(gameObject);
    }
}
