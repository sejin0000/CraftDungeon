using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour // Enmey ������Ʈ�� ������ ��ũ��Ʈ
{
    public EnemyData enemyData;
    public EnemyRoad enemyRoad;

    [SerializeField]
    private int hp;
    [SerializeField]
    private int damage;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private int exp;
    public float unBeatTime = 0.01f;

    public SpriteRenderer spr;
    public Rigidbody2D rigid;

    PlayerController player;
    public bool invincibility = false;

    private void Awake()
    {
        rigid = GetComponent <Rigidbody2D>();
        spr = GetComponentInChildren <SpriteRenderer>();
        enemyRoad = GetComponent<EnemyRoad>();
    }
    private void Start()
    {
        player = GameManager.Instance.player;
        hp = enemyData.Hp;
        damage = enemyData.Damage;
        moveSpeed = enemyData.MoveSpeed;
        exp = enemyData.Exp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {

            EffectManager.instance.effectOn(collision.transform);
            KnockBack();
            Hit();

            ItemSO item = collision.gameObject.GetComponent<EquippedItem>().curItem;
            hp -= item.power;
            
            if (hp <= 0)
            {
                this.gameObject.SetActive(false);
                GameManager.Instance.currentRoomClearPoint -= 1;
                GameManager.Instance.player.AddExp(exp);
            }
        }
    }

    private void KnockBack()
    {
        StartCoroutine(KnockBack1());

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && !player.invincibility)
        {
            player.hp -= damage;

            Vector3 Dirvec = player.transform.position - transform.position;
            Debug.Log("Hello");
            player.GetComponent<Rigidbody2D>().AddForce(Dirvec.normalized * 3, ForceMode2D.Impulse);


            player.Hit();


        }
    }
    public void Hit()
    {
        StartCoroutine("UnBeatTime");
    }

    IEnumerator UnBeatTime()
    {

        spr.color = new Color32(255, 142, 142, 255);
        invincibility = true;

        yield return new WaitForSeconds(unBeatTime);

        spr.color = new Color32(255, 255, 255, 255);
        invincibility = false;

        yield return null;
    }
    IEnumerator KnockBack1()
    {
        enemyRoad.isKnockBack = true;
        Vector3 PlayerPos = GameManager.Instance.player.transform.position;
        Vector3 Dirvec = transform.position - PlayerPos;

        rigid.AddForce(Dirvec.normalized * 3, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        enemyRoad.isKnockBack = false;

    }

}
