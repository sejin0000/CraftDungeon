using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : TopDownAnmations
{

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        controller.OnAttackEvent += Attacking;
        controller.OnMoveEvent += Move;
        PlayerInventory.I.ChangeEquippedItemEvent += ItemTypeCheck;
    }

    private void Attacking()
    {
        animator.SetTrigger("Attack");
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool("IsRun", vector.magnitude > 0.5f); ;
    }

    public void ItemTypeCheck(ItemSO item)
    {
        if (item.type == Itemtype.MeleeWeapon)
        {
            animator.SetFloat("WeaponType", 0);
        }
        else
        {
            animator.SetFloat("WeaponType", 1);
        }
    }

}
