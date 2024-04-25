using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private Animator animator;
    [SerializeField]
    private GameObject closedHitbox, openHitbox;
    public AnimationClip openAnimation;
    private bool isTalking;
    [SerializeField]
    UnityEvent onDialogueEnd;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage(string message)
    {
        if (!isTalking)
        {
            dialogueManager.DisplaySimpleMessage(message, onDialogueEnd);
            isTalking = true;
        }
        else
        {
            dialogueManager.DisplayNextQuote();
        }
    }

    public void HideMessage()
    {
        dialogueManager.EndDialogue();
    }

    public void OpenGate()
    {
        animator.Play(openAnimation.name);
        closedHitbox.SetActive(false);
        openHitbox.SetActive(true);
        dialogueManager.EndDialogue();
    }

    public void StopTalking()
    {
        isTalking = false;
    }

}
