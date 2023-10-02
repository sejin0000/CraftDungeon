using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benck : MonoBehaviour
{
    public RectTransform rect;
    GameObject[] Slots = new GameObject[9];


    public void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            Slots[i] = SlotSetting.Instance.AddSlot();
            Slots[i].transform.SetParent(rect); 
        }
    }
}
