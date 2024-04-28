using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDisplay : MonoBehaviour
{
    // External components
    private GameData gameData;
    public GameObject firstUIElement;

    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        EventSystem.current.SetSelectedGameObject(firstUIElement);
    }

    public void CloseInventory()
    {
        gameData.ToggleInventory();
    }

}
