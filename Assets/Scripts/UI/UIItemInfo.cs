using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInfo : MonoBehaviour
{
    public ItemSO _item;
    public Image image;
    public Text _name;
    public Text _type;
    public Text _power;
    public Text _explain;

    public void DrawInfo(ItemSO item)
    {
        _item = item;
        image.sprite = item.sprite;
        _name.text = item.Name;
        if (item.type == Itemtype.MeleeWeapon)
        {
            _type.text = "근접 무기";
        }
        if (item.type == Itemtype.RangeWeapon)
        {
            _type.text = "원거리 무기";
        }
        if (item.type == Itemtype.Expendables)
        {
            _type.text = "소무품";
        }
        if (item.type == Itemtype.Combination)
        {
            _type.text = "조합 아이템";
        }
        _power.text = item.power.ToString();
        _explain.text = item.explain.ToString();
    }

    public void ChangeItem()
    {
        if (_item == null)
        {
            Debug.LogWarning("아이템이 비었습니다");
        }
        PlayerInventory.I.CallChangeEquippedItemEvent(_item);
    }
}
