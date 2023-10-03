using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Data", menuName = "Shop/Shop Data", order = 0)]
public class ShopSO : ScriptableObject
{
    public List<ItemSO> shopItems = new List<ItemSO>();
}
