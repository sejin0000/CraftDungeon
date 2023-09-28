using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    
    public Vector2 inputVec;
    public Vector2 mousePos;
    public float moveSpeed = 5f;
    public float level;
    public float curExp;
    public float maxExp;
    public float hp;
    private Rigidbody2D rigid;

    private float fireDelay = 0;
    private bool isFireReady;
    public WeaponController equipWeapon;

    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;
    [SerializeField] private SpriteRenderer characterSpriter;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        characterSpriter = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        moveSpeed = player.Speed;
        level = player.Level;
        hp = player.Hp;
        curExp = player.CurExp;
        maxExp = player.MaxExp;
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * moveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);


    }
    public void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>().normalized;
    }
    public void OnLook(InputValue value)
    {
        mousePos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>()).normalized;
        //Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        //mousePos = (worldPos - (Vector2)transform.position).normalized;

        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if(newAim.magnitude >= 0.9f)
        {
            Debug.Log("로테이트 실행");

            RotateArm(newAim);
        }
    }
    public void OnFire()
    {
        Attack();
    }

    void Attack()
    {
        if (equipWeapon == null)
            return;

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.speed < fireDelay;

        if(isFireReady)
        {
            equipWeapon.Use();
            //애니메이션
            fireDelay = 0;
        }

    }

    void RotateArm(Vector2 direction)
    {
        Debug.Log("로테이트 들어옴");
        Debug.Log(direction);
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        armRenderer.flipY = Mathf.Abs(rotZ) > 90f;
        characterSpriter.flipX = armRenderer.flipY;
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
        
    }

}