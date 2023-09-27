using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSettingManager : MonoBehaviour
{
    public static SlotSettingManager Instance;

    public RectTransform slotCase;
    public GameObject slot;
    Stack<GameObject> slots = new Stack<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void Setting()
    {
        while(slotCase.childCount != Inventory.Instance.inventory.Count)
        {
            if (slotCase.childCount < Inventory.Instance.inventory.Count)
            {
                GameObject _slot =  Instantiate(slot);
                _slot.transform.SetParent(slotCase);
                slots.Push(_slot);
            }
            else
            {
                GameObject _slot = slots.Pop();
                _slot.gameObject.GetComponent<ItemSlot>().CallDestroy();
            }
        }
    }
}
