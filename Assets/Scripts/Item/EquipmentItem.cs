using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    public ItemSO curItem;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = curItem.sprite;
        transform.localPosition = curItem.pos;
        if (curItem.type == Itemtype.RangeWeapon)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    private void Start()
    {
        PlayerInventory.I.ChangeEquippedItemEvent += ChangeItem;
    }

    public void ChangeItem(ItemSO item)
    {
        curItem = item;
        Awake();
    }
}