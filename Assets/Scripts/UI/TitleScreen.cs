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
