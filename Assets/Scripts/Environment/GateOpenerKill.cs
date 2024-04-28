using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenerKill : MonoBehaviour
{
    private Gate gate;
    private Interactable interactable;
    private bool playerNearby;
    private InputManager inputManager;

    private void Start()
    {
        gate = GetComponent<Gate>();
        interactable = GetComponent<Interactable>();
        inputManager = FindObjectOfType<InputManager>();
    }
    void OnEnable()
    {
        EnemyBehaviour.onEnemyKilled += CheckEnemiesAreDead;
    }


    void OnDisable()
    {
        EnemyBehaviour.onEnemyKilled -= CheckEnemiesAreDead;
    }

    private void Update()
    {
        if (playerNearby && inputManager.InteractInput)
        {
            int nbEnemiesRemaining = GameObject.FindGameObjectsWithTag("Enemy").Length;
            string[] plural = nbEnemiesRemaining > 1 ? new string[2] {"s", "nt"} : new string[2] {"", ""};
            gate.DisplayMessage($"{nbEnemiesRemaining} d�mon{plural[0]} emp�che{plural[1]} la porte de s'ouvrir.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerNearby = true;
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

    private void CheckEnemiesAreDead(Vector2 _position, KillMethod _killMethod)
    {
        // Wait a bit so the enemy that died is destroy
        Invoke(nameof(CheckAndDestroy), 1f);
    }

    private void CheckAndDestroy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            gate.OpenGate();
            interactable.DisableSelf();
            this.enabled = false;
        }
    }
}
