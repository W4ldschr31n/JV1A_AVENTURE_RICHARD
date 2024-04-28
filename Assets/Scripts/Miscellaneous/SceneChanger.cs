using UnityEditor;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    // External components
    public string sceneToLoad;
    private GameData gameData;
    // Properties
    public Direction arrivalDirection = Direction.Center;

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameData.ChangeScene(sceneToLoad, arrivalDirection);
        }
    }
}

public enum Direction // Helps to move to another scene
{
    Center,
    North,
    East,
    South,
    West
}