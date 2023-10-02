using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    new public string name;
    public Sprite sprite;
    public ItemType type;
    public int power;
    public string explanation;
}

public enum ItemType
{
    Weapon,
    Part
}