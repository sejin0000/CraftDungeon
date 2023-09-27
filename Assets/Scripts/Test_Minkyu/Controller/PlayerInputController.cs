using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake(); // 부모의 것 먼저 실행
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized; // 두 방향키를 눌렀을 때 대각선 속도 조정
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value) 
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();   // screen 좌표를 world 좌표로 변환해줘야함
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;
        if (newAim.magnitude >= .9f)   // magnitude는 크기를 의미
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value) 
    {
        IsAttacking = value.isPressed;
    }
}
