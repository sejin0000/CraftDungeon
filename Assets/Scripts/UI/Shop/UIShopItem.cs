using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    public ItemSO curitem;
    public Image itemImg;
    public Text itemName;
    public Text itemDescription;

    public void SetItemData(ItemSO data)
    {
        curitem = data;
        itemImg.sprite = data.sprite;
        itemName.text = data.name;
        itemDescription.text = data.explanation;
    }

    public void ItemBuy()
    {
        Inventory.Instance.AddItem(curitem);
    }
}
