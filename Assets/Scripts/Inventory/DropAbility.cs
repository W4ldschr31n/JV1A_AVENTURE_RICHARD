using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAbility : MonoBehaviour
{
    [SerializeField]
    private AbilityUnlock abilityUnlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            abilityUnlock.Unlock();
            Destroy(gameObject);
        }
    }
}
