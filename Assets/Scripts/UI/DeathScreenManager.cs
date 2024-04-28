using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    // External component
    private GameData gameData;
    // Internal component
    private Animator animator;
    // Properties
    public bool canInput;

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (canInput && Input.anyKeyDown)
        {
            gameData.ResurrectPlayer();
        }
    }

    public void ShowPanel()
    {
        // This sets canInput to True, see animation "DeathScreenOpen"
        animator.SetBool("IsOpen", true);
    }

    public void HidePanel()
    {
        // This sets canInput to false, see animation "DeathScreenClose"
        animator.SetBool("IsOpen", false);
    }
}
