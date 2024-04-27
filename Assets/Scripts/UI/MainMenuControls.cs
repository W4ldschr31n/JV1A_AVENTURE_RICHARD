using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuControls : MonoBehaviour
{
    [SerializeField]
    GameObject titleScreen;

    [SerializeField]
    private GameObject mainMenu, optionsMenu, keyboardControls, controllerControls;

    [SerializeField]
    private GameObject mainMenuFirst, optionsMenuFirst, keyboardControlsFirst, controllerControlsFirst;

    public void HideTitleScreen()
    {
        titleScreen.SetActive(false);
        // Show the menu after a few frames to avoid hitting the play button instantly
        Invoke(nameof(OptionsBackButton), 0.5f);
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("SceneInit");
    }

    public void OptionsButton()
    {
        CloseAllMenus();
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsMenuFirst);
    }

    public void QuitButton()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void KeyboardControlsButton()
    {
        CloseAllMenus();
        keyboardControls.SetActive(true);
        EventSystem.current.SetSelectedGameObject(keyboardControlsFirst);
    }

    public void ControllerControlsButton()
    {
        CloseAllMenus();
        controllerControls.SetActive(true);
        EventSystem.current.SetSelectedGameObject(controllerControlsFirst);
    }

    public void OptionsBackButton()
    {
        CloseAllMenus();
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainMenuFirst);
    }

    public void RebindBackButton()
    {
        CloseAllMenus();
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsMenuFirst);
    }

    private void CloseAllMenus()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(false);
        keyboardControls.SetActive(false);
        controllerControls.SetActive(false);
    }
}
