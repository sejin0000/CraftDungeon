using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    // �ϳ��� gameManager�� �������� singleton�� ������ �ְ�, �� Manager�� �ٸ� Manager���� ������ �ְԲ�
    [SerializeField] private ParticleSystem _impactParticleSystem;

    public static ProjectileManager Instance;
    // ���� �޸𸮵��� ������ ������. Ŭ���� ������ �ν��Ͻ� ���� ����
    // �������� object���� ������� ��, �Ϲ����� �������� ������ object�� �Ҵ������,
    // static�� ���� �޸𸮿� �Ҵ�ް�, object�� �� �޸𸮸� �����ϰ� ��
    // singleton�� ���� �������� ������ ���� �ʴ븦 �� �� ����.
    // �� ������ �غ��ϱ� ����, ���� ��ü�� ���� �ϳ����� �����ϰ� ����.(Manager��)
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
