using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    // Internal components
    private DialogueManager dialogueManager;
    private Animator animator;

    // External components
    [SerializeField]
    private GameObject closedHitbox, openHitbox;
    public AnimationClip openAnimation;

    // Properties
    private bool isTalking;

    // Unity event
    [SerializeField]
    UnityEvent onDialogueEnd;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        animator = GetComponent<Animator>();
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
        // Switch hitbox
        closedHitbox.SetActive(false);
        openHitbox.SetActive(true);
        dialogueManager.EndDialogue();
    }

    public void StopTalking()
    {
        isTalking = false;
    }

}
