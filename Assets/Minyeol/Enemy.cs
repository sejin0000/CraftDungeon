using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // Enmey 오브젝트가 가지는 스크립트
{
    public EnemyData enemyData;

    [SerializeField]
    private int hp;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        hp = enemyData.Hp;
        damage = enemyData.Damage;
        moveSpeed = enemyData.MoveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // 내 체력 깎기(Bullet과 player의 weapon의 데미지 합 만큼)
        }
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("현재" + hp);
            
            hp -= collision.transform.GetComponent<Weapon>().weaponData.Damage;
            
            // 내 체력 깎기(player의 weapon 데미지만큼)
            Debug.Log("무기 데미지" + collision.transform.GetComponent<Weapon>().weaponData.Damage);
            Debug.Log("피격" + hp);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerController>().hp -= damage;
        }
    }

}
