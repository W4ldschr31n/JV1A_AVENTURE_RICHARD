using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SealsDisplay : MonoBehaviour
{
    [SerializeField]
    private Image seal1Image, seal2Image;
    [SerializeField]
    private Sprite seal1Sprite, seal2Sprite, emptySealSprite;
    private Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        seal1Image.sprite = inventory.hasFirstSeal ? seal1Sprite : emptySealSprite;
        seal2Image.sprite = inventory.hasSecondSeal ? seal2Sprite : emptySealSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
