using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "Scriptable Object/Weapon Data", order = -1)]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private string weaponName;
    public string WeaponName { get { return weaponName; } }

    [SerializeField]
    private int damage;
    public int Damage { get { return damage; } }

    [SerializeField]
    private float speed; // weapon�� ���ݼӵ�, bullet�� �߻�ӵ�
    public float Speed { get { return speed; } }

    [SerializeField]
    private Sprite weaponSprite;
    public Sprite WeaponSprite { get { return weaponSprite; } }
}
