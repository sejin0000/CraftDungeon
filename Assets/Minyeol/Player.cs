using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Stat")]
    [SerializeField]
    private string playerName;
    public string PlayerName { get { return playerName; } }

    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }

    [SerializeField]
    private int level;
    public int Level { get { return level; } }

    [SerializeField]
    private float curExp; // 경험치 슬라이더에 curExp / maxExp로 표시 할 예정
    public float CurExp { get { return curExp; } }

    [SerializeField]
    private float maxExp;
    public float MaxExp { get { return maxExp; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } }

    public Player(string _playerName, int _hp, int _level, float _curExp, float _maxExp, float _speed)
    {
        playerName = _playerName;
        hp = _hp;
        level = _level;
        curExp = _curExp;
        maxExp = _maxExp;
        speed = _speed;
    }

}
