using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class DropItem : MonoBehaviour
{
   
    [SerializeField] private ItemObjectList itemObjectList;

    private Character character;

    private void Start()
    {
        character = GetComponent<Character>();
        character.EventOnDeath.AddListener(Drop);
    }

    private void Drop()
    {
        character.EventOnDeath.RemoveAllListeners();
        if (itemObjectList != null)
        {
            ItemObject itemObject = itemObjectList.ItemsObject[Random.Range(0, itemObjectList.ItemsObject.Length)];
            GameObject drop = Instantiate(itemObject.ItemPrefab);
            GetItem getItem = drop.GetComponent<GetItem>();
            getItem.item = itemObject;
            drop.transform.position = transform.position;
            
        }     
    } 
}
