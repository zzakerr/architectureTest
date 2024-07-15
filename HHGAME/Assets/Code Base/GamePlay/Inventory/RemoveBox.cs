using UnityEngine;
using UnityEngine.EventSystems;

public class RemoveBox : MonoBehaviour , IPointerDownHandler
{
    private Slots slot;

    public void SetSlot(Slots slot)
    {
        this.slot = slot;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Inventory.Instance.RemoveItem(slot);
        gameObject.SetActive(false);
    }
}
