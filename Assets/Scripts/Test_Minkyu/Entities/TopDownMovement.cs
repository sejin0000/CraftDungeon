using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private CharacterStatusHandler _stats;

    private Vector2 _movementDirection = Vector2.zero;

    private Rigidbody2D _rigidbody;

    private Vector2 _knockback = Vector2.zero;
    private float knockbackDuration = 0f;

    private void Awake()
    {
        // 컨트롤러는 같은 곳에 달려있기 때문에, GetComponent를 활용
        // inspector 안에서 component들끼리 서로를 인지할 수 있는 방법
        _controller = GetComponent<TopDownCharacterController>();  
        _stats = GetComponent<CharacterStatusHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() // 보통 물리처리가 끝난 이후에 업데이트됨. (호출이 Update() 보다 느림)
    {
        ApplyMovement(_movementDirection);
        if (knockbackDuration > 0f) 
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Start()
    {
        // _controller에 구독을 함. 키보드를 누르면,
        // PlayerInputController에서 상위에 있는 TopDownCharacterController에 Move 메서드의 direction을 전달을 함.
        // TopDownCharacterController에서 구독하고 있는, TopDownMovement가 실행이 됨.
        _controller.OnMoveEvent += Move; 
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        _knockback = -(other.position - transform.position).normalized * power;
    }
    private void ApplyMovement(Vector2 direction)
    {
        direction *= _stats.CurrentStats.speed;
        if (knockbackDuration > 0f) 
        {
            direction += _knockback;
        }
        _rigidbody.velocity = direction;
    }
}
