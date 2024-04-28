using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    // External data
    public string sceneToRestart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        foreach(DontDestroyOnLoad element in FindObjectsOfType<DontDestroyOnLoad>())
        {
            Destroy(element.gameObject);
        }
        SceneManager.LoadScene(sceneToRestart);
    }
}
