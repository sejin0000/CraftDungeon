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
        StartCoroutine("Think");
    }

    void Start()
    {
        target = GameManager.Instance.player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Think() // 행동패턴 결정
    {
        yield return new WaitForSeconds(0.1f);

        int ranAction = Random.Range(0, 5);
        switch(ranAction)
        {
            case 0:
            case 1:
                StartCoroutine("Pattern1");
                break;
            case 2:
            case 3:
                StartCoroutine("Pattern2");

                break;
            case 4:
                StartCoroutine("Pattern3");

                break;

        }

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
