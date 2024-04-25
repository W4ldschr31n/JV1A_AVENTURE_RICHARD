using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDisplay : MonoBehaviour
{
    private GameData gameData;
    public GameObject firstUIElement;
    // Start is called before the first frame update
    void Start()
    {
        gameData = FindObjectOfType<GameData>();
        EventSystem.current.SetSelectedGameObject(firstUIElement);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseInventory()
    {
        gameData.ToggleInventory();
    }

}
