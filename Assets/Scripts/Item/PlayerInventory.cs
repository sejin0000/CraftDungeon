using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Action<ItemSO> ChangeEquippedItemEvent;

    public static PlayerInventory I;

    public ItemSO EquippedItem;

    public int inventoySize = 20;

    private void Awake()
    {
        I = this;
    }

    public void CallChangeEquippedItemEvent(ItemSO item)
    {
        EquippedItem = item;
        ChangeEquippedItemEvent?.Invoke(item);
    }
}
