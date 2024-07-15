using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "ScriptableObjects/ItemList")]
public class ItemObjectList:ScriptableObject
{
    [SerializeField] private string nameList;
    [SerializeField] private ItemObject[] itemsObject;
    public ItemObject[] ItemsObject => itemsObject;
}
