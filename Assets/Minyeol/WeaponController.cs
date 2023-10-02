using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int type; // 0 : 원거리무기, 1 : 근거리 무기
    public int prefabId; // 총알을 오브젝트 풀링 하기 위해 선언
    public float damage; // 공격력
    public float speed; // 공격 속도(원거리무기는 발사주기, 연사속도) => 1/speed로 쓸 생각
    public BoxCollider2D attackArea; // 공격범위
    public TrailRenderer trailEffect;

    PlayerController player;
    Weapon weapon;

    private void Start()
    {
        player = GameManager.instance.player;
        //weapon = transform.GetChild(0).GetComponent<Weapon>();
        weapon = GetComponentInChildren<Weapon>();
        speed = weapon.weaponData.Speed;
        if(type == 0) damage = weapon.weaponData.Damage; //원거리는 제작레벨을 bullet에서 적용시킬 예정
        else damage = weapon.weaponData.Damage + player.level; //플레이어의 제작 레벨이 오를수록 무기 데미지가 강해짐

        // 무기를 생성하는 함수(이후 구현)
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
                //speed는 휘두르기 쿨타임
                //클릭시 휘두르기 함수
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
        yield return new WaitForSeconds(1/speed); // 공격속도만큼 대기
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
    // Use() 메인루틴 -> Swing() 서브루틴 -> Use() 메인루틴
    // Use() 메인루틴 + Swing() 코루틴 ()
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