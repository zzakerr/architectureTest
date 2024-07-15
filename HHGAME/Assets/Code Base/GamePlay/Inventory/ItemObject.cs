using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    Bullet,
    Weapon,
    Armor
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items")]
public class ItemObject : ScriptableObject
{
    [SerializeField] private ItemType type;
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemPreview;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int count;
    [SerializeField] private int maxItemStack;

    public GameObject ItemPrefab => itemPrefab;
    public ItemType Type => type;
    public string ItemName => itemName;
    public Sprite ItemPreview => itemPreview;
    public int MaxItemStack => maxItemStack;
    public int Count => count;
    public bool IsStackable => IsStackable;

}

