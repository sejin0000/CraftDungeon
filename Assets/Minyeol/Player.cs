using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField]
    private string playerName;

    [SerializeField]
    private int hp;

    [SerializeField]
    private int level;

    [SerializeField]
    private float curExp; // ����ġ �����̴��� curExp / maxExp�� ǥ�� �� ����

    [SerializeField]
    private float maxExp;

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } }

    //public Weapon weapon;


    void Awake()
    {
        //�ӽ� ����
        playerName = "Knight";
        hp = 100;
        level = 5;
        curExp = 50f;
        maxExp = 100f;
        speed = 7f;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
