using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    public float level;
    public float curExp;
    public float maxExp;
    public float hp;
    public float unBeatTime = 0.5f;
    public SpriteRenderer[] spr = new SpriteRenderer[3];
    public Rigidbody2D rigid;

    public bool invincibility = false;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
        level = player.Level;
        hp = player.Hp;
        curExp = player.CurExp;
        maxExp = player.MaxExp;
    }

    public void AddExp(int exp)
    {
        curExp += exp;
        if (maxExp <= curExp)
        {
            curExp = curExp - maxExp;
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        maxExp += 20;
        hp = player.Hp;
    }
    public void Hit()
    {
        EffectManager.instance.effectOn(transform);
        StartCoroutine("UnBeatTime");
    }

    IEnumerator UnBeatTime() 
    {

        foreach (var _spr in spr)
        {
            _spr.color = new Color32(142, 142, 142, 255);
            invincibility = true;
        }

        yield return new WaitForSeconds(unBeatTime);

        foreach (var _spr in spr)
        {
            //Alpha Effect End
            _spr.color = new Color32(255, 255, 255, 255);
            invincibility = false;
        }
        yield return null;
    }
}
