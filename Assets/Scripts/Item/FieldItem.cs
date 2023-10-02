using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItem : MonoBehaviour
{
    public ItemSO curItem;
    private SpriteRenderer icon;

    private void Awake()
    {
        icon = GetComponentInChildren<SpriteRenderer>();
        icon.sprite = curItem.sprite;
    }
}
