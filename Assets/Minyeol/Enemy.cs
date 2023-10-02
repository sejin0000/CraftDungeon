using System;
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
    [SerializeField]
    private int exp;
    public float unBeatTime = 0.01f;


    public SpriteRenderer[] spr = new SpriteRenderer[3];
    public Rigidbody2D rigid;

    PlayerController player;
    public bool invincibility = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // �� ü�� ���(Bullet�� player�� weapon�� ������ �� ��ŭ)
        }
        if (collision.gameObject.CompareTag("Weapon"))
        {

            EffectManager.instance.effectOn(collision.transform);

            Debug.Log("����" + hp);

            ItemSO item = collision.gameObject.GetComponent<EquippedItem>().curItem;
            hp -= item.power;

            // �� ü�� ���(player�� weapon ��������ŭ)
            Debug.Log("���� ������" + item.power);
            Debug.Log("�ǰ�" + hp);
            KnockBaek();
            Hit();
            if (hp <= 0)
            {
                this.gameObject.SetActive(false);
                GameManager.Instance.player.AddExp(exp);
            }
        }
    }

    private void KnockBaek()
    {
        StartCoroutine("KnockBack");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.gameObject.CompareTag("Player") && !player.invincibility)
        {
            player.hp -= damage;
            player.Hit();
        }
    }
    public void Hit()
    {
        StartCoroutine("UnBeatTime");
    }

    IEnumerator UnBeatTime()
    {

        foreach (var _spr in spr)
        {
            _spr.color = new Color32(255, 142, 142, 255);
            invincibility = true;
        }

        yield return new WaitForSeconds(unBeatTime);

        foreach (var _spr in spr)
        {
            //Alpha Effect End
            _spr.color = new Color32(255, 255, 255, 255);
            invincibility = false;
        }
        yield return null;
    }

    IEnumerator KnockBack()
    {
        Vector3 PlayerPos = player.transform.position;
        Vector3 Dirvec = transform.position - PlayerPos;

        rigid.AddForce(Dirvec.normalized * 3,ForceMode2D.Impulse);
        yield return null;
    }
}
