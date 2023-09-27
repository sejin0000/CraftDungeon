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
        GetComponentInChildren<SpriteRenderer>().sprite = curItem.�̹���;
        obj = curItem.������;
    }

    public FieldItem(GameObject item)
    {
        obj = item;
        GetComponentInChildren<SpriteRenderer>().sprite = obj.GetComponent<Item>().�̹���;
        curItem = obj.GetComponent<Item>();
    }

    private void Start()
    {
        if (obj != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = obj.GetComponent<Item>().�̹���;// �ӽ�
            curItem = obj.GetComponent<Item>();
        }
        if (curItem != null)
        {
            GetComponentInChildren<SpriteRenderer>().sprite = curItem.�̹���;// �ӽ�
            obj = curItem.������;
        }
    }

    public void CallDestroy()
    {
        Destroy(gameObject);
    }
}
