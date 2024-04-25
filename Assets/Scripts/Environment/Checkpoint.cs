using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Landmark landmark;
    private MinimapManager minimapManager;
    private GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        minimapManager = FindObjectOfType<MinimapManager>();
        gameData = FindObjectOfType<GameData>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            minimapManager.VisitLandmark(landmark);
            gameData.spawnPoint = transform.position;
        }
    }
}
