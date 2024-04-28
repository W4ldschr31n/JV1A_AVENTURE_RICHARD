using UnityEngine;

public class UnlockCharge : MonoBehaviour
{
    // External component
    private GameData gameData;

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
    }

    public void Unlock()
    {
        gameData.UnlockCharge();
    }
}
