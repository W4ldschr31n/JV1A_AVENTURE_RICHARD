using UnityEngine;

public class UnlockJudgement : MonoBehaviour
{
    // External component
    private GameData gameData;

    private void Start()
    {
        gameData = FindObjectOfType<GameData>();
    }

    public void Unlock()
    {
        gameData.UnlockJudgement();
    }
}
