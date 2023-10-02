using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class SlotSetting : MonoBehaviour
{
    public static SlotSetting Instance;

    public RectTransform InvenRect;
    public GameObject InvenSlot;
    public GameObject slot;

    private int slotCount;
    private List<GameObject> slots = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        slotCount = Inventory.Instance.inventorySize;
        for(int i = 0; i < slotCount; i++)
        {
            GameObject go = Instantiate(InvenSlot);
            go.transform.SetParent(InvenRect);
            slots.Add(go);
        }
    }

    public bool AddInventory(ItemSO item)
    {
        for (int i = 0; i < slotCount; i++)
        {
            if (slots[i].transform.childCount == 0)
            {
                Debug.Log("슬롯 추가");
                GameObject go = Instantiate(slot);
                go.GetComponent<Slot>().curItem = item;
                go.transform.SetParent(slots[i].transform);
                go.transform.position = slots[i].transform.position;
                return true;
            }
            else
            {
                Debug.Log("남은 슬롯이 없습니다");
            }
        }
        return false;
    }

    public GameObject AddSlot()
    {
        GameObject Obj = Instantiate(InvenSlot);
        return Obj;
    }







}
