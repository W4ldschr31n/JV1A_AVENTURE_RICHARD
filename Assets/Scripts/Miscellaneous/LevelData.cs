using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Transform spawnNorth;
    public Transform spawnSouth;
    public Transform spawnEast;
    public Transform spawnWest;
    public Transform spawnCenter;

    private Dictionary<Direction, Transform> spawnDict = new Dictionary<Direction, Transform>();

    void Awake()
    {
        spawnDict.Add(Direction.North, spawnNorth);
        spawnDict.Add(Direction.South, spawnSouth);
        spawnDict.Add(Direction.East, spawnEast);
        spawnDict.Add(Direction.West, spawnWest);
    }

    public Vector2 GetSpawnPoint(Direction dir)
    {
        return spawnDict.GetValueOrDefault(dir, spawnCenter).position;
    }
}
