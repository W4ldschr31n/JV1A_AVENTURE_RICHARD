using UnityEngine;
using UnityEngine.UI;

public class SealsDisplay : MonoBehaviour
{
    // External components
    [SerializeField]
    private Image seal1Image, seal2Image;
    [SerializeField]
    private Sprite seal1Sprite, seal2Sprite, emptySealSprite;
    private Inventory inventory;

    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        seal1Image.sprite = inventory.hasFirstSeal ? seal1Sprite : emptySealSprite;
        seal2Image.sprite = inventory.hasSecondSeal ? seal2Sprite : emptySealSprite;
    }
}
