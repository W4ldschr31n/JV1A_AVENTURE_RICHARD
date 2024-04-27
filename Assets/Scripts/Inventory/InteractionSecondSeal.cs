using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionSecondSeal : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private InputManager inputManager;
    private bool isEnabled;
    public UnityEvent onDialogueEnd;
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
            dialogueManager.DisplayNextQuote();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueManager.EndDialogue();
        }
    }

    public void TriggerDialogue()
    {
        isEnabled = true;
        dialogueManager.DisplaySimpleMessage("Vous trouvez le <b>sceau de la fureur</b>. FIN DU JEU");
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
