using UnityEngine;

public class InputDisplay : MonoBehaviour
{
    // External components
    [SerializeField]
    private GameObject imageBindController, textBindKeyboard;
    private InputDisplayManager inputDisplayManager;

    private void Start()
    {
        inputDisplayManager = FindObjectOfType<InputDisplayManager>();
        UpdateDisplay();
    }

    void OnEnable()
    {
        InputDisplayManager.onInputPressed += UpdateDisplay;
    }

    private void OnDisable()
    {
        InputDisplayManager.onInputPressed -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        textBindKeyboard.SetActive(inputDisplayManager.isKeyboard);
        imageBindController.SetActive(!inputDisplayManager.isKeyboard);
    }
}
