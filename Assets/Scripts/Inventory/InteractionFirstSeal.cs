using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionFirstSeal : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private InputManager inputManager;
    private bool isEnabled;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnabled && inputManager.InteractInput)
        {
            DestroySelf();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroySelf();
        }
    }

    public void TriggerDialogue()
    {
        isEnabled = true;
        dialogueManager.DisplaySimpleMessage("Vous trouvez le <b>sceau de la justice</b>.");
    }

    private void DestroySelf()
    {
        dialogueManager.EndDialogue();
        Destroy(gameObject);
    }
}
