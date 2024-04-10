using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenerKill : MonoBehaviour
{
    private Gate gate;
    private bool isActif = true;

    private void Start()
    {
        gate = GetComponent<Gate>();
    }
    void OnEnable()
    {
        EnemyBehaviour.onEnemyKilled += CheckEnemiesAreDead;
    }


    void OnDisable()
    {
        EnemyBehaviour.onEnemyKilled -= CheckEnemiesAreDead;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActif && collision.gameObject.CompareTag("Judgement"))
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length + " ennemis restant");
        }
    }

    private void CheckEnemiesAreDead(GameObject _enemy, Vector2 _position, KillMethod _killMethod)
    {
        // Wait a bit so the enemy that died is destroy
        Invoke("CheckAndDestroy", 0.5f);
    }

    private void CheckAndDestroy()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            gate.OpenGate();
            isActif = false;
        }
    }
}
