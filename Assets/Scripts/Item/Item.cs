using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item :MonoBehaviour
{
    public string �̸�;
    public Sprite �̹���;
    public Itemtype Ÿ��;
    public int �Ŀ�;
    public string ����;
    public GameObject ������;
}

public enum Itemtype
{
    MeleeWeapon,//��������
    RangeWeapon,//���Ÿ�����
    Expendables,//�Ҹ�ǰ
    Combination,//���� ������
}