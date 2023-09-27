using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item :MonoBehaviour
{
    public string 이름;
    public Sprite 이미지;
    public Itemtype 타입;
    public int 파워;
    public string 설명;
    public GameObject 프리팹;
}

public enum Itemtype
{
    MeleeWeapon,//근접무기
    RangeWeapon,//원거리무기
    Expendables,//소모품
    Combination,//조합 아이템
}