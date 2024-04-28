using UnityEngine;

public class PowersDisplay : MonoBehaviour
{
    // External components
    [SerializeField]
    private GameObject judgementDisplay, oboleDisplay, chargeDisplay;
    private InputDisplayManager inputDisplayManager;

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
        // Allow to not have every power displayed in the panel
        if (judgementDisplay != null) {
            judgementDisplay.SetActive(inputDisplayManager.canDisplayJudgement);
        }
        if (oboleDisplay != null) {
            oboleDisplay.SetActive(inputDisplayManager.canDisplayObole);
        }
        if (chargeDisplay != null) {
            chargeDisplay.SetActive(inputDisplayManager.canDisplayCharge);
        }
    }
}
