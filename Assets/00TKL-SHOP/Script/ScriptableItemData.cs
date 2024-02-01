using UnityEngine;

[CreateAssetMenu(fileName = "Equipment")]
public class ScriptableItemData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public GameObject Prefab;
}