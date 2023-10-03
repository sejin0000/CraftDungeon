using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private Transform CharaecterPos;

    bool _isMovingCheck = false;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        CharaecterPos = GetComponent<Transform>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
    }


    private void FixedUpdate()
    {
        ApplyMovment(_movementDirection);
        if (!_isMovingCheck)
        {
            _isMovingCheck = true;
            //Debug.Log(CharaecterPos.position);
            StartCoroutine(CallSeconds());
        }

    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * GetComponent<Player>().Speed;

        _rigidbody.velocity = direction;
    }

    IEnumerator CallSeconds()
    {
        yield return new WaitForSeconds(1f);
        _isMovingCheck = false;
    }
}