using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearEnemiesPuzzle : MonoBehaviour
{
    public List<GameObject> objectsToDestroy;

    void OnEnable()
    {
        EnemyBehaviour.onEnemyKilled += CheckEnemiesAreDead;
    }


    void OnDisable()
    {
        EnemyBehaviour.onEnemyKilled -= CheckEnemiesAreDead;
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
            foreach (GameObject go in objectsToDestroy)
            {
                Destroy(go);
            }
        }
    }
}
