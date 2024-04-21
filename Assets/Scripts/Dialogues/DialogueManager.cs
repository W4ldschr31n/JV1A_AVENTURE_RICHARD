using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    private Queue<string> quotes;
    private string quoteToDisplay;
    private bool isCoroutinePlaying;
    [SerializeField]
    private Animator animator;

    private void Start()
    {
        quotes = new Queue<string>();
        isCoroutinePlaying = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // Build the queue from the dialogue array
        quotes = new Queue<string>(dialogue.quotes);

        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.npcName;
        DisplayNextQuote();
    }

    public void DisplaySimpleMessage(string message)
    {
        // In case we want to display one dynamic message
        quotes = new Queue<string>();
        quotes.Enqueue(message);

        animator.SetBool("IsOpen", true);
        nameText.text = string.Empty;
        DisplayNextQuote();
    }

    public void DisplayNextQuote()
    {
        if (isCoroutinePlaying)
        { // If a quote is being written, display the remaining text
            StopAllCoroutines();
            dialogueText.text = quoteToDisplay;
            isCoroutinePlaying=false;
        }
        else if (quotes.Count > 0)
        { // If there is a next quote, dequeue it and display it
            quoteToDisplay = quotes.Dequeue();
            StartCoroutine(DisplayQuote(quoteToDisplay));
            isCoroutinePlaying = true;
        }
        else
        { // If there is no quote left, close dialogue
            EndDialogue();
        }
    }

    private IEnumerator DisplayQuote(string quote)
    {
        dialogueText.text = "";
        foreach(string part in WrapRichText(quote))
        { // Write letters one by one (skip blanks)
            dialogueText.text += part;
            if(part != " ")
            {
                yield return new WaitForSeconds(0.05f);
            }
        }
        isCoroutinePlaying = false;
    }
    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

    private List<string> WrapRichText(string quote)
    {
        // Will transform 'Hello <b>world</b>' into 'Hello <b>w</b><b>o</b><b>r</b><b>l</b><b>d</b>'
        List<string> result = new List<string> ();
        string currentPart = "";
        bool isRichTag = false;
        bool isRichTagStart = false;
        bool isRichTagEnd = false;
        bool isRichText = false;
        string tmpRichTagStart = "";
        string tmpRichTagEnd = "";
        string tmpRichText = "";
        // Wrap every single letter of rich text instead of words
        foreach(char letter in quote.ToCharArray())
        {
            // Opening tag
            if (letter == '<' && !isRichTagStart)
            {
                isRichTag = true;
                isRichTagStart = true;
                currentPart = letter.ToString();
            }
            else if (letter == '>' && !isRichTagEnd)
            {
                currentPart += letter;
                tmpRichTagStart = currentPart;
                isRichTag = false;
                isRichText = true;
                currentPart = "";
            }
            // Closing tag
            else if (letter == '<')
            {
                isRichTag = true;
                isRichTagEnd = true;
                isRichText = false;
                currentPart = letter.ToString();
            }
            else if (letter == '>')
            {
                currentPart += letter;
                tmpRichTagEnd = currentPart;
                foreach (char richLetter in tmpRichText.ToCharArray())
                {
                    result.Add(tmpRichTagStart + richLetter + tmpRichTagEnd);
                }
                tmpRichText = "";
                isRichTag = false;
                isRichTagStart = false;
                currentPart = "";
            }
            // Content of tag
            else if (isRichTag)
            {
                currentPart += letter;
            }
            // Content between tags
            else if (isRichText)
            {
                tmpRichText += letter;
            }
            // Normal text
            else
            {
                result.Add(letter.ToString());
            }
        }
        return result;
    }
}
