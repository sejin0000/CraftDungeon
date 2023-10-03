using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    public Image curitem;
    public Image itemImg;
    public Text itemName;
    public Text itemDescription;

    public void SetItemData(ItemSO data)
    {
        itemImg.sprite = data.sprite;
        itemName.text = data.name;
        itemDescription.text = data.explanation;
    }
}
