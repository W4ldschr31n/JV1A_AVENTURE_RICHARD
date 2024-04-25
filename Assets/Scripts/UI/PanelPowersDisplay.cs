using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowersDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject judgementDisplay, oboleDisplay, chargeDisplay;
    private InputDisplayManager inputDisplayManager;
    private Image panel;
    // Start is called before the first frame update
    void Start()
    {
        inputDisplayManager = FindObjectOfType<InputDisplayManager>();
        panel = GetComponent<Image>();
        UpdateDisplay();
    }

    private void OnEnable()
    {
        GameData.onAbilityUnlocked += UpdateDisplay;
    }

    private void OnDisable()
    {
        GameData.onAbilityUnlocked -= UpdateDisplay;
    }

    void UpdateDisplay()
    {
        bool displayPanel = false;
        if (judgementDisplay != null) {
            judgementDisplay.SetActive(inputDisplayManager.canDisplayJudgement);
            displayPanel |= inputDisplayManager.canDisplayJudgement;
        }
        if (oboleDisplay != null) {
            oboleDisplay.SetActive(inputDisplayManager.canDisplayObole);
            displayPanel |= inputDisplayManager.canDisplayObole;
        }
        if (chargeDisplay != null) {
            chargeDisplay.SetActive(inputDisplayManager.canDisplayCharge);
            displayPanel |= inputDisplayManager.canDisplayCharge;
        }
        panel.enabled = displayPanel;
    }
}
