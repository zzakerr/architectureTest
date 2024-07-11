using UnityEngine;

public enum ItemType
{
    Food,
    Weapon,
    Armor
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items")]
public class Item : ScriptableObject
{
    [SerializeField] private ItemType type;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemPreview;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int itemCount;
}
