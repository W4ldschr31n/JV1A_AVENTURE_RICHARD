using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantOboleOnDeath : MonoBehaviour
{
    private GameData gameData;
    private InputDisplayManager inputDisplayManager;

    private void Start()
    {
        gameData = FindObjectOfType<GameData>();
        inputDisplayManager = FindObjectOfType<InputDisplayManager>();
    }

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) // Prevents bugs when changing scene or quitting game
            return;
        
        // Make sure player did not skip the obole unlock
            if (!inputDisplayManager.canDisplayObole)
        {
            gameData.UnlockObole();
        }
    }
}
