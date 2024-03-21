using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    public Direction arrivalDirection = Direction.Center;
    private GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameData.ChangeScene(sceneToLoad.name, arrivalDirection);
        }
    }
}

public enum Direction
{
    Center,
    North,
    East,
    South,
    West
}