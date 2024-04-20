using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]
    GameObject titlePanel, mainMenu;
    void Update()
    {
        if (Input.anyKey)
        {
            mainMenu.SetActive(true);
            titlePanel.SetActive(false);
        }
    }
}
