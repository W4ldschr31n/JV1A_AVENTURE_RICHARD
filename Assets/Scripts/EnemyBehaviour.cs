using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemyBehaviour : MonoBehaviour
{
    public int damage;
    public static event Action<Vector2, KillMethod> onEnemyKilled;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControl>().TakeHit(damage);
        }
        else if (collision.gameObject.CompareTag("Judgement"))
        {
            onEnemyKilled?.Invoke(transform.position, KillMethod.Judgement);
            Destroy(gameObject.transform.parent.gameObject);
        }
        else if (collision.gameObject.CompareTag("Obole"))
        {
            onEnemyKilled?.Invoke(transform.position, KillMethod.Obole);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }


}


public enum KillMethod
{
    Judgement,
    Obole,
}