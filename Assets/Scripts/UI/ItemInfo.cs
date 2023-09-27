using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public ItemSO _curItem;
    public Image _image;
    public Text _name;
    public Text _type;
    public Text _power;
    public Text _explain;


    public void OpenInfo(ItemSO item)
    {
        _curItem = item;
        _image.sprite = item.sprite;
        _name.text = item.name;
        _type.text = item.type.ToString();
        _power.text = item.power.ToString();
        _explain.text = item.explain;

        gameObject.SetActive(true);
    }

    public void CloseInfo()
    {
        gameObject.SetActive(false);
    }
}
