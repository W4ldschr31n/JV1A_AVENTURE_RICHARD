using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    [SerializeField]
    MainMenuControls menuControls;
    void Update()
    {
        if (Input.anyKey)
        {
            menuControls.HideTitleScreen();
        }
    }
}
