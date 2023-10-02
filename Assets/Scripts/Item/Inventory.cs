using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    public List<ItemSO> inventory =  new List<ItemSO>();
    public int inventorySize = 10;


    private void Awake()
    {
        Instance = this;
    }

    public bool AddItem(ItemSO item)
    {
        if (item != null && InventorySizeCheck())
        {
            inventory.Add(item);
            SlotSetting.Instance.AddInventory(item);
            return true;
        }
        else
        {
            Debug.LogWarning("�κ��丮�� �߰��� �������� ������ �����ϴ�");
        }
        return false;
    }

    public void RemoveItem(ItemSO item)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
        }
        else
        {
            Debug.LogWarning("�������� ������ �κ��丮�� �����ϴ�");
        }
    }

    public bool InventorySizeCheck()
    {
        if (inventory.Count < inventorySize)
        {
            return true;
        }
        return false;
    }
}
