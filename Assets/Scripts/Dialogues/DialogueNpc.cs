using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueNpc : MonoBehaviour
{
    public Dialogue dialogue;
    private bool isPlayerInRange, isTalking;
    private DialogueManager dialogueManager;

    [SerializeField]
    UnityEvent onDialogueEnd;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.E))
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
