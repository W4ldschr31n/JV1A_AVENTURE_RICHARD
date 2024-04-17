using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpenerItem : MonoBehaviour
{
    private Gate gate;
    private bool isActif = true;
    private Inventory inventory;
    public Item item;
    public string message;

    private void Start()
    {
        gate = GetComponent<Gate>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActif && collision.gameObject.CompareTag("Judgement"))
        {
            if (inventory.CheckHasItem(item))
            {
                gate.OpenGate();
                isActif = false;
            }else
            {
                gate.DisplayMessage(message);
            }
        }
    }
}
