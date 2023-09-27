using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public ItemSO curItem;

    public FieldItem(ItemSO item)
    {
        curItem = item;
        GetComponentInChildren<SpriteRenderer>().sprite = curItem.sprite;
    }

    private void Start()
    {
        if (curItem != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = curItem.sprite;
        }
        else
        {
            Debug.LogWarning("curItem이 비어있습니다");
        }
    }

    public void CallDestroy()
    {
        Destroy(gameObject);
    }
}
