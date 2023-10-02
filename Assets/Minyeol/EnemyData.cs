using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = -1)]
public class EnemyData : ScriptableObject
{
    [SerializeField] 
    private string enemyName;
    public string EnemyName { get { return enemyName; } }
    [SerializeField] 
    private int hp;
    public int Hp { get { return hp; } }
    // 1. public int hp
    // 2. set{}
    // 3. Enemy ����
    [SerializeField] 
    private int damage;
    public int Damage { get { return damage; } }
    [SerializeField] 
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField] 
    private Sprite enemySprite;
    public Sprite EnemySprite { get {  return enemySprite; } }

    [SerializeField]
    private int exp;
    public int Exp { get { return exp; } }
}
