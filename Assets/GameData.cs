using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    public int visitedScreens = 0;
    public Vector2 spawnPoint = Vector2.zero;
    private Movement player;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += onSceneLoaded;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(visitedScreens);
        }
    }

    private void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player.Respawn();
    }
}
