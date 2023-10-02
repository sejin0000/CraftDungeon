using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int type; // 0 : ���Ÿ�����, 1 : �ٰŸ� ����
    public int prefabId; // �Ѿ��� ������Ʈ Ǯ�� �ϱ� ���� ����
    public float damage; // ���ݷ�
    public float speed; // ���� �ӵ�(���Ÿ������ �߻��ֱ�, ����ӵ�) => 1/speed�� �� ����
    public BoxCollider2D attackArea; // ���ݹ���
    public TrailRenderer trailEffect;

    PlayerController player;
    Weapon weapon;

    private void Start()
    {
        player = GameManager.instance.player;
        //weapon = transform.GetChild(0).GetComponent<Weapon>();
        weapon = GetComponentInChildren<Weapon>();
        speed = weapon.weaponData.Speed;
        if(type == 0) damage = weapon.weaponData.Damage; //���Ÿ��� ���۷����� bullet���� �����ų ����
        else damage = weapon.weaponData.Damage + player.level; //�÷��̾��� ���� ������ �������� ���� �������� ������

        // ���⸦ �����ϴ� �Լ�(���� ����)
    }

    private void Update()
    {
/*        switch(type)
        {
            case 0:
                timer += Time.deltaTime;

                if(timer > speed)
                {
                    //Fire();
                }
                break;
            default:
                //speed�� �ֵθ��� ��Ÿ��
                //Ŭ���� �ֵθ��� �Լ�
                break;

        }*/
    }

    public void Use()
    {
        if(type == 0)
        {
            StopCoroutine("Swing");
            StartCoroutine("Swing");
        }
    }
    IEnumerator Swing()
    {
        Debug.Log("swing");
        //1
        yield return new WaitForSeconds(1/speed); // ���ݼӵ���ŭ ���
        attackArea.enabled = true;
        trailEffect.enabled = true;

        Debug.Log("attackArea");

        yield return new WaitForSeconds(0.1f);
        attackArea.enabled = false;

        Debug.Log("traileffect");

        yield return new WaitForSeconds(0.1f);
        trailEffect.enabled = false;

        Debug.Log("strop coroutine");


        //2
    }
    // Use() ���η�ƾ -> Swing() �����ƾ -> Use() ���η�ƾ
    // Use() ���η�ƾ + Swing() �ڷ�ƾ ()
}


/*void Fire()
{
    if (!player.scanner.nearestTarget)
        return;

    Vector3 targetPos = player.scanner.nearestTarget.position;
    Vector3 dir = targetPos - transform.position;
    dir = dir.normalized;

    Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
    bullet.position = transform.position;
    bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
    bullet.GetComponent<BulletController>().Init(damage, count, dir);

}*/