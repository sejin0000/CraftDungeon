using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObject/Item", order = int.MinValue)]
[System.Serializable]
public class ItemSO : ScriptableObject
{
    public string Name;
    public Sprite sprite;
    public Itemtype type;
    public int power;
    public string explain;
    public Vector3 pos;
    public Vector3 rot = new Vector3(0,0,-45);
}

public enum Itemtype
{
    MeleeWeapon,//��������
    RangeWeapon,//���Ÿ�����
    Expendables,//�Ҹ�ǰ
    Combination,//���� ������
}