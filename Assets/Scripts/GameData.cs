using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    private Direction spawnDirection;
    private Vector2 spawnPoint = Vector2.zero;
    private PlayerControl player;
    private CameraFollow mainCamera;
    private LevelData levelData;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        SceneManager.LoadScene(1); // SceneMilieu
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void MovePlayerToSpawn()
    {
        player.transform.position = spawnPoint;
        mainCamera.transform.position = new Vector3(spawnPoint.x, spawnPoint.y, mainCamera.transform.position.z);
    }

    public void ChangeScene(string sceneName, Direction newSpawnDirection)
    {
        spawnDirection = newSpawnDirection;
        SceneManager.LoadScene(sceneName);
    }

    private void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        levelData = FindObjectOfType<LevelData>();
        spawnPoint = levelData.GetSpawnPoint(spawnDirection);
        MovePlayerToSpawn();
    }
}
