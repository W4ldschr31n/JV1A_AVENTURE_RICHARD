using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    // Properties
    public Dictionary<Landmark, bool> visitedLandmarks;

    void Start()
    {
        visitedLandmarks = new Dictionary<Landmark, bool>();
    }

    public void VisitLandmark(Landmark landmark)
    {
        visitedLandmarks[landmark] = true;
    }

    public bool CheckLandmarkIsVisited(Landmark landmark)
    {
        return visitedLandmarks.GetValueOrDefault(landmark, false);
    }
}


public enum Landmark // Helps to display the minimap
{
    StyxCenter,
    StyxNorth,
    StyxSouth,
    StyxEast,
    StyxWest,

    ElyseumCenter,
    ElyseumNorth,
    ElyseumSouth,
    ElyseumEast,
    ElyseumWest,

    SheolCenter,
    SheolNorth,
    SheolSouth,
    SheolEast,
    SheolWest,
}