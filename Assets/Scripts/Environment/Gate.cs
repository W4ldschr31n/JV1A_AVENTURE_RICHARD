using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private Animator animator;
    [SerializeField]
    private GameObject closedHitbox, openHitbox;
    public AnimationClip openAnimation;
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
        dialogueManager.DisplaySimpleMessage(message);
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

}
