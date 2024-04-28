using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCharge : MonoBehaviour
{
    private GameData gameData;
    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
    }

    public void Unlock()
    {
        gameData.UnlockCharge();
    }
}
