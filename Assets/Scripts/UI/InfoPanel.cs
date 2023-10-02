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

    public ItemSO _item;
    public Slot _slot;

    public void OpenInfo(Slot slot)
    {
        ItemSO item = slot.GetComponent<Slot>().curItem;


        _icon.sprite = item.sprite;
        _name.text = item.name;
        _type.text = item.type.ToString();
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
    }

    public void equipment()
    {
        Debug.Log("{0}장비 하였습니다", _item);
    }
}
