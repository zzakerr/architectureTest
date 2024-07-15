using UnityEngine;
using static UnityEditor.Progress;


public class Inventory : SingletonBase<Inventory>
{
    [SerializeField] private Slots[] slot;

    private void Start()
    {
        Init();
    }

    public void AddItem(ItemObject item,int count)
    {
        for(int i = 0; i < slot.Length; i++)
        {    
            if(slot[i].ItemObject == null)
            {
                slot[i].UpdateSlots(item, count);
                return;
            }
            if(slot[i].ItemObject == item)
            {
                if (slot[i].ItemObject.Type == ItemType.Weapon || slot[i].ItemObject.Type == ItemType.Armor)
                {
                    continue;
                }
                slot[i].UpdateSlots(item, count);
                return;
            }

            Debug.Log("Места нет");
        }
    }

    public void RemoveItem(Slots slots)
    {
        slots.ClearSlot();
    }

    public bool IsAmmo(ItemObject bullet)
    {
        int count = -1;
        for (int i = 0; i < slot.Length; i++)
        {
            if (slot[i].ItemObject == bullet)
            {
                slot[i].UpdateSlots(bullet, count);
                return true;
            }
        }
        return false;
    }

}
