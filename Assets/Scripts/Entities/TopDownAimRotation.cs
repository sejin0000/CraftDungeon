using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private Transform armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 newAimDirection)
    {
        RotateArm(newAimDirection);
    }

    private void RotateArm(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;// 벡터 값을 각도로 환산해줌

        if (Mathf.Abs(rotZ) > 90f)
        {
            armPivot.transform.localScale = new Vector3(-1, 1, 1);
            characterRenderer.flipX = true;
            armPivot.rotation = Quaternion.Euler(0, 0, rotZ - 180);
        }
        else
        {
            armPivot.transform.localScale = new Vector3(1, 1, 1);
            characterRenderer.flipX = false;
            armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
}