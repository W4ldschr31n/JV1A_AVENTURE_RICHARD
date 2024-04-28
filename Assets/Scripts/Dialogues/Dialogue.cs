using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    public string npcName;
    [TextArea(3,5)]
    public string[] quotes;
}
