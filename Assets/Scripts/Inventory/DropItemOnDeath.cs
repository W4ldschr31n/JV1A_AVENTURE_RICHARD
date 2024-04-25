using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    [SerializeField]
    private Item itemToDrop;
    [SerializeField]
    private GameObject dropPrefab;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) // Prevents bugs when changing scene or quitting game
            return;

        GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        drop.GetComponent<DropItem>().item = itemToDrop;

    }
}
