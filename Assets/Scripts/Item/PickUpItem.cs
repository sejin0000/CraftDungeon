using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            if (Inventory.Instance.AddItem(collision.GetComponent<FieldItem>().curItem))
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
