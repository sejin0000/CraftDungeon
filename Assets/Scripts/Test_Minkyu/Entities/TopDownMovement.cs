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
        // ��Ʈ�ѷ��� ���� ���� �޷��ֱ� ������, GetComponent�� Ȱ��
        // inspector �ȿ��� component�鳢�� ���θ� ������ �� �ִ� ���
        _controller = GetComponent<TopDownCharacterController>();  
        _stats = GetComponent<CharacterStatusHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() // ���� ����ó���� ���� ���Ŀ� ������Ʈ��. (ȣ���� Update() ���� ����)
    {
        ApplyMovement(_movementDirection);
        if (knockbackDuration > 0f) 
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Start()
    {
        // _controller�� ������ ��. Ű���带 ������,
        // PlayerInputController���� ������ �ִ� TopDownCharacterController�� Move �޼����� direction�� ������ ��.
        // TopDownCharacterController���� �����ϰ� �ִ�, TopDownMovement�� ������ ��.
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
