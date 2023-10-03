using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBomb : MonoBehaviour
{
    public Transform target;
    public Rigidbody2D rigid;
    Vector3 vec;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        vec = target.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.MovePosition(transform.position + vec * 2f * Time.fixedDeltaTime);    
    }

    private void Update()
    {
        if(transform.position == target.position)
        {
            gameObject.SetActive(false);
        }
    }
}
