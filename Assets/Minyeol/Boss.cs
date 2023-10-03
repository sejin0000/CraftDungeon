using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bomb;
    public Transform missilePort;
    public Transform target;

    Vector3 lookVec;

    private void Awake()
    {
        
    }

    void Start()
    {
        target = GameManager.Instance.player.transform;
        StartCoroutine("Think");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Think() // 행동패턴 결정
    {
        yield return new WaitForSeconds(0.1f);

        StartCoroutine("Pattern1");

    }

    IEnumerator Pattern1()
    {
        GameObject instantBomb = Instantiate(bomb, missilePort.position, missilePort.rotation);
        BossBomb bossBomb = instantBomb.GetComponent<BossBomb>();
        bossBomb.target = target;


        yield return new WaitForSeconds(2f);
        StartCoroutine("Think");
    }
    IEnumerator Pattern2()
    {
        yield return null;
        StartCoroutine("Think");
    }
    IEnumerator Pattern3()
    {
        yield return null;
        StartCoroutine("Think");
    }
}
