using UnityEngine;

public class InteractPanelManager : MonoBehaviour
{
    // External component
    [SerializeField]
    private GameObject interactpanel;

    private void Start()
    {
        HidePanel();
    }
    public void ShowPanel()
    {
        interactpanel.SetActive(true);
    }

    public void HidePanel()
    {
        // Check not null in case we close the game
        if (interactpanel != null)
            interactpanel.SetActive(false);
    }
}
