using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenManager : MonoBehaviour
{
    private GameData gameData;
    private Animator animator;
    public bool canInput;

    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
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
