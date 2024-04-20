using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuControls : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, optionsMenu;

    [SerializeField]
    private GameObject mainMenuFirst, optionsMenuFirst;

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
    public void BackButton()
    {
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(mainMenuFirst);

        optionsMenu.SetActive(false);
    }
}
