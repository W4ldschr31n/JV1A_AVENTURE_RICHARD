using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNpc : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isPlayerInRange;
    private DialogueManager dialogueManager;

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
        dialogueManager.StartDialogue(dialogue);
    }
}
