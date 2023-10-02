using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public static GameManager Instance;
    public PlayerController player;

    private void Awake()
    {
        Instance = this;
    }
}
