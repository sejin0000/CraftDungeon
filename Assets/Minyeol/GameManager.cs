using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player;
    public CameraFollow cameraFollow;

    private void Awake()
    {
        Instance = this;
    }

}
