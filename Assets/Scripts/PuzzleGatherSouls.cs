using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGatherSouls : MonoBehaviour
{
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
        Debug.Log("Outch");
        if (collision.gameObject.CompareTag("Judgement"))
        {
            Debug.Log(GameObject.FindGameObjectsWithTag("LostSoul"));
        }
    }
}
