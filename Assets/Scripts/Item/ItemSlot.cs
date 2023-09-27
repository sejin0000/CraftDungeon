using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemSlot : MonoBehaviour
{
    public ItemSO curItem;
    public Image icon;


    public ItemSlot(ItemSO item)
    {
        curItem = item;
    }
    private void Start()
    {
        icon.sprite = curItem.sprite;
        transform.localScale = Vector3.one;
    }

    public void OpenInfo()
    {
        UIManager.Instance.OpenInfo(curItem);
    }
}
