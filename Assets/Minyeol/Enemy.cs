using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // Enmey 오브젝트가 가지는 스크립트
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
            // 내 체력 깎기(Bullet과 player의 weapon의 데미지 합 만큼)
        }
        if(collision.gameObject.CompareTag("Weapon"))
        {
            // 내 체력 깎기(player의 weapon 데미지만큼)
        }

    }
}
