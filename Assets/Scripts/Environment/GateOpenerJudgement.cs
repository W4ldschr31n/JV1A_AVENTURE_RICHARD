using UnityEngine;

public class GateOpenerJudgement : MonoBehaviour
{
    // Internal components
    private Gate gate;
    private Interactable interactable;

    // External components
    private InputManager inputManager;

    // Properties
    private bool playerNearby;

    private void Start()
    {
        gate = GetComponent<Gate>();
        interactable = GetComponent<Interactable>();
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
            interactable.DisableSelf();
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
