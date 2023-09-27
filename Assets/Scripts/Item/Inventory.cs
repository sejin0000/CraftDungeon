using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<ItemSO> inventory = new List<ItemSO>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemSO item)
    {
        inventory.Add(item);
        SlotSettingManager.Instance.Setting();
    }

    public void RemoveItem(ItemSO item)
    {
        inventory.Remove(item);
        SlotSettingManager.Instance.Setting();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            FieldItem item = collision.GetComponent<FieldItem>();
            inventory.Add(item.curItem);
            item.CallDestroy();
            SlotSettingManager.Instance.Setting();
        }
    }
}