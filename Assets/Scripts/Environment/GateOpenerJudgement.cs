using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenerJudgement : MonoBehaviour
{
    private Gate gate;
    private bool playerNearby;
    private InputManager inputManager;

    private void Start()
    {
        gate = GetComponent<Gate>();
        inputManager = FindObjectOfType<InputManager>();
    }

    private void Update()
    {
        if(playerNearby && inputManager.InteractInput)
        {
            gate.DisplayMessage("Sonnez la trompette du jugement pour ouvrir la porte.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
        }else if(collision.gameObject.CompareTag("Judgement"))
        {
            gate.OpenGate();
            this.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = false;
            gate.HideMessage();
        }
    }
}
