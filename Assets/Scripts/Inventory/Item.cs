using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite sprite;
}
