using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogue : MonoBehaviour
{

    [TextArea][SerializeField]
    private string[] dialogues;
    private DialogueText dialogueText;
    private int currentDialogueIndex;

    private void Start()
    {
        currentDialogueIndex = 0;
        dialogueText = FindObjectOfType<DialogueText>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Judgement"))
        {
            RunDialogue();
        }
    }


    private void RunDialogue()
    {
        if(currentDialogueIndex < dialogues.Length)
        {
            // Read current dialogue and increment index
            dialogueText.DisplayMessage(dialogues[currentDialogueIndex++]);
        }
        else
        {
            dialogueText.DisplayMessage("...", 1f);
        }
    }

    public void CutDialogue()
    {
        // Rewind dialogue if player runs away
        currentDialogueIndex = Mathf.Max(0, currentDialogueIndex-1);
        dialogueText.HideMessage();
    }
}
