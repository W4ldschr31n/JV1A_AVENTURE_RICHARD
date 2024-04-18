using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDetectionArea : MonoBehaviour
{
    [SerializeField]
    private NpcDialogue npcDialogue;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            npcDialogue.CutDialogue();
        }
    }
}
