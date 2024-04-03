using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyBehaviour : MonoBehaviour
{
    public int damage;
    public static event Action<Vector2> onEnemyJudged;
    public static event Action<Vector2> onEnemyOboled;

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
            onEnemyJudged?.Invoke(transform.position);
        }
        else if (collision.gameObject.CompareTag("Obole"))
        {
            onEnemyOboled?.Invoke(transform.position);
        }
    }


}
