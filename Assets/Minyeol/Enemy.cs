using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // Enmey ������Ʈ�� ������ ��ũ��Ʈ
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
            // �� ü�� ���(Bullet�� player�� weapon�� ������ �� ��ŭ)
        }
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("����" + hp);
            
            hp -= collision.transform.GetComponent<Weapon>().weaponData.Damage;
            
            // �� ü�� ���(player�� weapon ��������ŭ)
            Debug.Log("���� ������" + collision.transform.GetComponent<Weapon>().weaponData.Damage);
            Debug.Log("�ǰ�" + hp);
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
