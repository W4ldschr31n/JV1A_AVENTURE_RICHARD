using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGatherSouls : MonoBehaviour
{

    public List<GameObject> objectsToDestroy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (
            collision.gameObject.CompareTag("Judgement") 
            && 
            GameObject.FindGameObjectsWithTag("LostSoul").Length == 0
        )
        {
            foreach (GameObject go in objectsToDestroy)
            {
                Destroy(go);
            }
        }
    }
}
