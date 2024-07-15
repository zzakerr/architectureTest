using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour , IPointerDownHandler
{
    [SerializeField] private Text countText;
    [SerializeField] private Image iconImage;
    [SerializeField] private RemoveBox removeBox;


    private ItemObject itemObject;
    private int currentCount;


    public ItemObject ItemObject => itemObject;

    private void Start()
    {
        countText.text = string.Empty;
    }

    public void UpdateSlots(ItemObject itemObject, int count)
    {
        if (this.itemObject == null) 
        { 
            this.itemObject = itemObject;
            iconImage.sprite = itemObject.ItemPreview;
            currentCount = count;
            if (itemObject.MaxItemStack != 1)
            {
                countText.text = "" + currentCount;
            }
        }
        else
        {
            if (itemObject.MaxItemStack != 1)
            {
                currentCount += count;
                countText.text = "" + currentCount;
            }
        }

        if (currentCount <= 0)
        {
            ClearSlot();
        }

    }

    public void ClearSlot()
    {
        itemObject = null;
        countText.text = "";
        iconImage.sprite = null;
        currentCount = 0;
    }

    private bool IsActive;
    public void OnPointerDown(PointerEventData eventData)
    {
        IsActive = !IsActive;
        if (itemObject != null)
        {
            removeBox.gameObject.SetActive(IsActive);
            removeBox.SetSlot(this);
            removeBox.transform.position = transform.position;
        }       
    }
}
