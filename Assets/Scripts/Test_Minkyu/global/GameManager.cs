using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform Player { get; private set; }
    [SerializeField] private string playerTag;

    private void Awake()
    {
        instance = this;
        playerTag = "Player";
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;
    }
}