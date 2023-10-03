using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InfoPanel : MonoBehaviour
{
    public GameObject infoPanel;


    public Image _icon;
    public Text _name;
    public Text _type;
    public Text _power;
    public Text _ex;
    public Text _button;

    public ItemSO _item;
    public Slot _slot;

    public void OpenInfo(Slot slot)
    {
        ItemSO item = slot.GetComponent<Slot>().curItem;


        _icon.sprite = item.sprite;
        _name.text = item.name;

        if (item.type == ItemType.Weapon)
        {
            _type.text = "무기";
            _button.text = "장착";
        }
        if (item.type == ItemType.Part)
        {
            _type.text = "소모품";
            _button.text = "사용";
        }

        _power.text = item.power.ToString();
        _ex.text = item.explanation.ToString();
    infoPanel.SetActive(true);

        _item = item;
        _slot = slot;
    }

    public void CloseInfo()
    {
        infoPanel.SetActive(false);
    }

    public void Remove()
    {
        Destroy(_slot.gameObject);
        Inventory.Instance.RemoveItem(_item);
        infoPanel.SetActive(false);
        EquippedItem.Instance.EquipItemRemove(_item);
    }

    public void equipment()
    {
        if (_item.type == ItemType.Weapon)
        {
            Debug.Log(_item.name);
            EquippedItem.Instance.EquipItem(_item);
        }
        if (_item.type == ItemType.Part)
        {
            Debug.Log("아이템을 사용했습니다");
        }

    }
}
