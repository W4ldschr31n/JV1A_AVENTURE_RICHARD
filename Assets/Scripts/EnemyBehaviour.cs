using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemyBehaviour : MonoBehaviour
{
    public int damage;
    public static event Action<GameObject, KillMethod> onEnemyKilled;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControl>().TakeHit(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Judgement"))
        {
            onEnemyKilled?.Invoke(gameObject.transform.parent.gameObject, KillMethod.Judgement);
        }
        else if (collision.gameObject.CompareTag("OboleProjectile"))
        {
            onEnemyKilled?.Invoke(gameObject.transform.parent.gameObject, KillMethod.Obole);
        }
    }


}


public enum KillMethod
{
    Judgement,
    Obole,
}