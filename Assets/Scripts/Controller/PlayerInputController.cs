using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;

        CallMoveEvent(moveInput);//�̺�Ʈ ȣ��
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 WorldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (WorldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);//�̺�Ʈ ȣ��
    }


    public void OnAttack(InputValue value)
    {
        CallAttackEvent();
    }

}
