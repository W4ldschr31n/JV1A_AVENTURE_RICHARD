using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public SceneAsset sceneToLoad;
    public Direction arrivalSpot;
    private GameData gameData;
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Adios");
            collision.gameObject.GetComponent<Movement>().spawnPoint = new Vector2(-transform.position.x, 0);
            SceneManager.LoadScene(sceneToLoad.name);
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