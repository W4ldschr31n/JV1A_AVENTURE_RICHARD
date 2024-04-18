using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/JudgementUnlock", order = 2)]
public class JudgementUnlock : AbilityUnlock
{
    public override void Unlock()
    {
        GameData gameData = FindObjectOfType<GameData>();
        gameData.UnlockJudgement();
    }
}
