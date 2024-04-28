using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // External data
    public Landmark landmark;

    // External components
    private MinimapManager minimapManager;
    private GameData gameData;

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
