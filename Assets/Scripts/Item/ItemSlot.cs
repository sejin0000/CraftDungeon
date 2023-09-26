using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item curItem;
    public Image icon;
    public ItemSlot(Item item)
    {
        curItem = item;
    }
    private void Start()
    {
        icon.sprite = curItem.¿ÃπÃ¡ˆ;
    }
}
