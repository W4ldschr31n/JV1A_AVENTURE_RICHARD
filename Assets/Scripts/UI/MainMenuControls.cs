using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuControls : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, optionsMenu, keyboardControls, controllerControls;

    [SerializeField]
    private GameObject mainMenuFirst, optionsMenuFirst, keyboardControlsFirst, controllerControlsFirst;


    public void PlayButton()
    {
        SceneManager.LoadScene("SceneInit");
    }

    public void OptionsButton()
    {
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsMenuFirst);
        mainMenu.SetActive(false);
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
        optionsMenu.SetActive(false);
        keyboardControls.SetActive(true);
        EventSystem.current.SetSelectedGameObject(keyboardControlsFirst);
    }

    public void ControllerControlsButton()
    {
        optionsMenu.SetActive(false);
        controllerControls.SetActive(true);
        EventSystem.current.SetSelectedGameObject(controllerControlsFirst);
    }

    public void OptionsBackButton()
    {
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainMenuFirst);

        optionsMenu.SetActive(false);
    }

    public void RebindBackButton()
    {
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionsMenuFirst);

        keyboardControls.SetActive(false);
        controllerControls.SetActive(false);
    }
}
