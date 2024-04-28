using UnityEngine;
using UnityEngine.UI;

public class LandmarkDisplay : MonoBehaviour
{
    // External data
    public Landmark landmark;
    // External components
    private MinimapManager minimapManager;
    // Internal components
    private Image image;

    void Start()
    {
        minimapManager = FindObjectOfType<MinimapManager>();
        image = GetComponent<Image>();

        // Only display the map part associated to the landmark if we visited it
        image.enabled = minimapManager.CheckLandmarkIsVisited(landmark);
    }

}
