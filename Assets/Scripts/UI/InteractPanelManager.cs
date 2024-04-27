using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPanelManager : MonoBehaviour
{
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
        interactpanel.SetActive(false);
    }
}
