using UnityEngine;

public class GrantOboleOnDeath : MonoBehaviour
{
    // External components
    private GameData gameData;
    private InputDisplayManager inputDisplayManager;

    private void Start()
    {
        gameData = FindObjectOfType<GameData>();
        inputDisplayManager = FindObjectOfType<InputDisplayManager>();
    }

    private void OnDestroy()
    {
        // Prevents bugs when changing scene or quitting game
        if (!gameObject.scene.isLoaded)
            return;
        
        // Make sure player did not skip the obole unlock
            if (!inputDisplayManager.canDisplayObole)
        {
            gameData.UnlockObole();
        }
    }
}
