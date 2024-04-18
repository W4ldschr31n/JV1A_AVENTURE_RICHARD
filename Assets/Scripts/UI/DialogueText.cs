using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueText : MonoBehaviour
{
    private Text text;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<Text>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage(string message, float displayTime = 0f)
    {
        text.text = message;
        text.enabled = true;
        image.enabled = true;
        if(displayTime > 0f)
        {
            Invoke("HideMessage", displayTime);
        }
    }

    public void HideMessage()
    {
        text.enabled = false;
        image.enabled = false;
    }
}
