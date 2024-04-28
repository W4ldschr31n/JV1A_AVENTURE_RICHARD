using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ChargeUnlock", order = 2)]
public class ChargeUnlock : AbilityUnlock
{
    public override void Unlock()
    {
        GameData gameData = FindObjectOfType<GameData>();
        gameData.UnlockCharge();
    }
}
