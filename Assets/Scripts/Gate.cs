using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private DialogueText dialogueText;
    // Start is called before the first frame update
    void Start()
    {
        dialogueText = GameObject.FindGameObjectWithTag("DialogueText").GetComponent<DialogueText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage(string message)
    {
        dialogueText.DisplayMessage(message, 1.5f);
    }

    public void OpenGate()
    {
        Destroy(this.gameObject);
    }

}
