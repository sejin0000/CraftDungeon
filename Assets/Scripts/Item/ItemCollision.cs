using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour
{
    public RectTransform invenPanel;
    public GameObject slot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Item" )
        {
            ItemSO item = collision.gameObject.GetComponent<FieldItem>().curItem;


            GameObject go = Instantiate(slot);
            go.GetComponent<ItemSlot>().curItem = item;
            go.transform.SetParent(invenPanel);

            collision.gameObject.GetComponent<FieldItem>().CallDestroy();
        }
    }
}
