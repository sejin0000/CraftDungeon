using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour  // 클래스의 이름과 파일명이 같아야함.
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackSO> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;

    protected CharacterStatusHandler Stats { get; private set; }
    protected bool IsAttacking { get; set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStatusHandler>();
    }
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (Stats.CurrentStats.attackSO == null)
            return;

        if (_timeSinceLastAttack <= Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (IsAttacking && _timeSinceLastAttack > Stats.CurrentStats.attackSO.delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(Stats.CurrentStats.attackSO);
        }
    }
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}


//// public으로 선언할 경우
////public float speed = 5f;

//// private으로 선언할 경우
////[SerializeField] private float speed = 5f;


//// Start is called before the first frame update
//void Start()
//{

//}

//// Update is called once per frame
//void Update()
//{
//    //// 트랜스폼 좌표를 활용하는 방법
//    //float x = Input.GetAxis("Horizontal");
//    //float y = Input.GetAxis("Vertical");

//    //transform.position += new Vector3(x, y) * Time.deltaTime * speed;
//    //// 리지드 바디를 통해 이동하는 방법
//}