using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // Enmey ������Ʈ�� ������ ��ũ��Ʈ
{
    public EnemyData enemyData;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
           // enemyData.Hp -= GameManager.instance.player.weapon.
        }
        if(collision.gameObject.CompareTag("Bullet"))
        {
            // �� ü�� ���(Bullet�� player�� weapon�� ������ �� ��ŭ)
        }
        if(collision.gameObject.CompareTag("Weapon"))
        {
            // �� ü�� ���(player�� weapon ��������ŭ)
        }

    }
}
