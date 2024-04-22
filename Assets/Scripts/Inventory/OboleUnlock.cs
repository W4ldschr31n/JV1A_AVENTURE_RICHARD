using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/OboleUnlock", order = 2)]
public class OboleUnlock : AbilityUnlock
{
    public override void Unlock()
    {
        GameData gameData = FindObjectOfType<GameData>();
        gameData.UnlockObole();
    }
}
