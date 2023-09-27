using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // 하나의 gameManager를 만들어놓고 singleton을 가지고 있고, 이 Manager가 다른 Manager들을 가지고 있게끔
    [SerializeField] private ParticleSystem _impactParticleSystem;

    public static ProjectileManager Instance;
    // 정적 메모리들은 공간을 공유함. 클래스 명으로 인스턴스 접근 가능
    // 여러개의 object들을 만들었을 때, 일반적인 변수들은 각각의 object에 할당받지만,
    // static은 정적 메모리에 할당받고, object는 이 메모리를 참조하게 됨
    // singleton은 제일 마지막에 참조한 곳만 초대를 할 수 있음.
    // 이 단점을 극복하기 위해, 단일 객체를 만들어서 하나에만 접근하게 만듦.(Manager급)
    private ObjectPool objectPool;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        objectPool = GetComponent<ObjectPool>();
    }
    public void ShootBullet(Vector2 startPosition, Vector2 direction, RangedAttackData attackData)
    {
        GameObject obj = objectPool.SpawnfromPool(attackData.bulletNameTag);

        obj.transform.position = startPosition;
        RangedAttackController attackCOntroller = obj.GetComponent<RangedAttackController>();
        attackCOntroller.InitializeAttack(direction, attackData, this);
        obj.SetActive(true);
    }

}
