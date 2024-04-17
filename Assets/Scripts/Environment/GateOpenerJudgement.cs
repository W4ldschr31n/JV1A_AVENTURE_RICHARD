using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenerJudgement : MonoBehaviour
{
    private Gate gate;
    private bool isActif = true;

    private void Start()
    {
        gate = GetComponent<Gate>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActif && collision.gameObject.CompareTag("Judgement"))
        {
            gate.OpenGate();
            isActif = false;
        }
    }
}
