using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public Dictionary<Landmark, bool> visitedLandmarks;
    // Start is called before the first frame update
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


public enum Landmark
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