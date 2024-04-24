using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject judgementDisplay, oboleDisplay, chargeDisplay;
    private InputDisplayManager inputDisplayManager;
    // Start is called before the first frame update
    void Start()
    {
        inputDisplayManager = FindObjectOfType<InputDisplayManager>();
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
        if(judgementDisplay != null)
            judgementDisplay.SetActive(inputDisplayManager.canDisplayJudgement);
        if (oboleDisplay != null)
            oboleDisplay.SetActive(inputDisplayManager.canDisplayObole);
        if (chargeDisplay != null)
            chargeDisplay.SetActive(inputDisplayManager.canDisplayCharge);
    }
}
