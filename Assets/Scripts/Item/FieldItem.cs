using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public GameObject obj;
    public Item curItem;

    public FieldItem(Item item)
    {
        curItem = item;
        GetComponentInChildren<SpriteRenderer>().sprite = curItem.이미지;
        obj = curItem.프리팹;
    }

    public FieldItem(GameObject item)
    {
        obj = item;
        GetComponentInChildren<SpriteRenderer>().sprite = obj.GetComponent<Item>().이미지;
        curItem = obj.GetComponent<Item>();
    }

    private void Start()
    {
        if (obj != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = obj.GetComponent<Item>().이미지;// 임시
            curItem = obj.GetComponent<Item>();
        }
        if (curItem != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = curItem.이미지;// 임시
            obj = curItem.프리팹;
        }
    }

    public void CallDestroy()
    {
        Destroy(gameObject);
    }
}
