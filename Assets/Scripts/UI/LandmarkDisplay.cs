using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkDisplay : MonoBehaviour
{
    private MinimapManager minimapManager;
    public Landmark landmark;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        minimapManager = FindObjectOfType<MinimapManager>();
        image = GetComponent<Image>();

        // Only display the map aprt associated to the landmark when we visited it
        image.enabled = minimapManager.CheckLandmarkIsVisited(landmark);
    }

}
