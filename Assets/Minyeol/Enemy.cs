using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // Enmey ������Ʈ�� ������ ��ũ��Ʈ
{
    public EnemyData enemyData;



    /*    private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
               // enemyData.Hp -= GameManager.instance.player.weapon.
            }


        }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // �� ü�� ���(Bullet�� player�� weapon�� ������ �� ��ŭ)
        }
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("����" + enemyData.Hp);

            enemyData.Hp -= collision.transform.GetComponent<Weapon>().weaponData.Damage;
            //enemyData.Hp = -collision.transform.GetComponent<Weapon>().weaponData.Damage;
            
            // �� ü�� ���(player�� weapon ��������ŭ)
            Debug.Log("���� ������" + collision.transform.GetComponent<Weapon>().weaponData.Damage);
            Debug.Log("�ǰ�" + enemyData.Hp);
        }
    }

}
