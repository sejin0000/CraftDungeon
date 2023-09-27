using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemSlot : MonoBehaviour
{
    public int slotNumber;

    public ItemSO curItem;
    public Image icon;
    public GameObject Info;

    public ItemSlot(ItemSO item)
    {
        curItem = item;
    }

    private void Start()
    {
        curItem = Inventory.Instance.inventory[slotNumber];
        icon.sprite = curItem.sprite;
        transform.localScale = Vector3.one;
    }

    public void CallDestroy()
    {
        Destroy(gameObject);
    }

    public void OpenInfo()
    {
        UIManager.Instance.InfoPanel.GetComponent<ItemInfo>().OpenInfo(curItem);
    }
}
