using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopDownCharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    float AttackDelay = 1;
    float AttackCoolTime = 0;

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent()
    {
        if (AttackCoolTime < 0 && EventSystem.current.IsPointerOverGameObject() == false)
        {
            AttackCoolTime = AttackDelay;
            OnAttackEvent?.Invoke();
        }
    }


    private void Update()
    {
        AttackCoolTime -= Time.deltaTime;
    }
}
