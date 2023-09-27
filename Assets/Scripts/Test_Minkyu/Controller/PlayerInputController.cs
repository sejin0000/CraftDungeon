using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake(); // �θ��� �� ���� ����
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        //Debug.Log("OnMove" + value.ToString());
        Vector2 moveInput = value.Get<Vector2>().normalized; // �� ����Ű�� ������ �� �밢�� �ӵ� ����
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value) 
    {
        //Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();   // screen ��ǥ�� world ��ǥ�� ��ȯ�������
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;
        if (newAim.magnitude >= .9f)   // magnitude�� ũ�⸦ �ǹ�
        {
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value) 
    {
        IsAttacking = value.isPressed;
    }
}
