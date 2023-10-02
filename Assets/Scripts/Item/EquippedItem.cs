using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItem : MonoBehaviour
{
    public static EquippedItem Instance;
    public ItemSO curItem;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void EquipItem(ItemSO item)
    {
        curItem = item;
        GetComponent<SpriteRenderer>().sprite = curItem.sprite;
        this.gameObject.SetActive(true);
    }

    public void EquipItemRemove(ItemSO item)
    {
        if(item ==  curItem)
        {
            this.gameObject.SetActive(false);
        }
    }
}
