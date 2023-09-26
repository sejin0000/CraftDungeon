using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    
    public Vector2 inputVec;
    private Vector2 moveDirection = Vector2.zero;
    public float moveSpeed = 5f;
    public float level;
    private Rigidbody2D rigid;
    private SpriteRenderer spriter;
    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
        moveSpeed = player.Speed;
        level = player.Level;
    }
    private void LateUpdate()
    {
        spriter.flipX = inputVec.x < 0;
    }
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * moveSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
    public void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}