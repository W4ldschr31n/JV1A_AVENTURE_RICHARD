using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCharge : MonoBehaviour
{
    private GameData gameData;

    private void Start()
    {
        gameData = FindObjectOfType<GameData>();
    }

    public void Unlock()
    {
        gameData.UnlockCharge();
    }
}
