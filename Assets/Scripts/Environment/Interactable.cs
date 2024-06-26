using UnityEngine;

public class Interactable : MonoBehaviour
{
    // External components
    private InteractPanelManager interactPanelManager;

    // Properties
    private bool isActivable = true;

    private void Start()
    {
        interactPanelManager = FindObjectOfType<InteractPanelManager>();
    }

    // Change to OnTriggerStay2D if interactables are overlapping
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActivable)
        {
            interactPanelManager.ShowPanel();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isActivable)
        {
            interactPanelManager.HidePanel();
        }
    }

    public void DisableSelf()
    {
        isActivable = false;
        interactPanelManager.HidePanel();
    }
}
