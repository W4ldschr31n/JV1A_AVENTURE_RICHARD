using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    private Direction spawnDirection;
    private Vector2 spawnPoint = Vector2.zero;
    private PlayerControl player;
    private CameraFollow mainCamera;
    private LevelData levelData;
    public GameObject obolePrefab;
    public GameObject faithPrefab;
    public const int FAITH_HEAL = 15;
    public SceneAsset sceneToPlay;
    public SceneAsset sceneInventory;
    public bool isInventoryOpen;
    // Start is called before the first frame update
    void Start()
    {
        // Init global stuff
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        isInventoryOpen = false;
        // Move player to the real game after init
        spawnDirection = Direction.Center;
        SceneManager.LoadScene(sceneToPlay.name);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        LostSoul.onLostSoulFreed += OnLostSoulFreed;
        EnemyBehaviour.onEnemyKilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        LostSoul.onLostSoulFreed -= OnLostSoulFreed;
        EnemyBehaviour.onEnemyKilled -= OnEnemyKilled;
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

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Move player if we move to another scene
        if (mode == LoadSceneMode.Single)
        {
            levelData = FindObjectOfType<LevelData>();
            // Init scene has no LevelData
            if(levelData != null)
            {
                spawnPoint = levelData.GetSpawnPoint(spawnDirection);
                MovePlayerToSpawn();
            }
        }
    }

    private void OnLostSoulFreed(LostSoul lostSoul)
    {
        Vector2 position = lostSoul.transform.position;
        int nbRewards = lostSoul.nbRewards;
        Destroy(lostSoul.gameObject);
        SpawnRewards(obolePrefab, nbRewards, position);
    }

    private void OnEnemyKilled(GameObject enemy, Vector2 position, KillMethod killMethod)
    {
        Destroy(enemy);
        // Get data for the rewards (judgement or charge ->obole; obole->faith)
        int nbRewards = GetRandomNbRewards();
        GameObject rewardObject = killMethod == KillMethod.Obole ? faithPrefab : obolePrefab;
        SpawnRewards(rewardObject, nbRewards, position);
    }

    private int GetRandomNbRewards()
    {
        // Custom randomizer to have 30% -> 0; 50% -> 1; 20% -> 2
        int rawResult = Random.Range(0, 100);
        return (
            rawResult <= 29 ? 0
            : rawResult <= 79 ? 1
            : 2
        );
    }

    private void SpawnRewards(GameObject rewardObject, int nbRewards, Vector2 position)
    {
        Vector2 offset; // So that the objects don't stack upon each other
        for (int i = 0; i < nbRewards; i++)
        {
            offset = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            Instantiate(rewardObject, position + offset, Quaternion.identity);
        }
    }

    public void ToggleInventory()
    {
        if (!isInventoryOpen)
        {
            isInventoryOpen = true;
            // 'Pause' the game
            Time.timeScale = 0f;
            SceneManager.LoadScene(sceneInventory.name, LoadSceneMode.Additive);
        } else
        {
            isInventoryOpen = false;
            // 'Resume' the game
            Time.timeScale = 1f;
            SceneManager.UnloadSceneAsync(sceneInventory.name);
        }
    }

    public void UnlockJudgement()
    {
        player.canJudgement = true;
    }

    public void UnlockObole()
    {
        player.canObole = true;
    }

    public void UnlockCharge()
    {
        player.canCharge = true;
    }
}
