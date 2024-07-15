using UnityEngine;

public class GetItem : MonoBehaviour
{
    public ItemObject item;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent?.GetComponent<Character>().NickName == "Player")
        {
            Inventory.Instance.AddItem(item,item.Count);
            Destroy(gameObject);
        }       
    }

}
