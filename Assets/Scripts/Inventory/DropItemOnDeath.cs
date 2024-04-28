using UnityEngine;

public class DropItemOnDeath : MonoBehaviour
{
    // External data
    [SerializeField]
    private Item itemToDrop;
    [SerializeField]
    private GameObject dropPrefab;

    private void OnDestroy()
    {
        // Prevents bugs when changing scene or quitting game
        if (!gameObject.scene.isLoaded)
            return;

        GameObject drop = Instantiate(dropPrefab, transform.position, Quaternion.identity);
        drop.GetComponent<DropItem>().item = itemToDrop;

    }
}
