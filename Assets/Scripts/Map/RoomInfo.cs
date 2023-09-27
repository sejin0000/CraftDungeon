using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo
{
    public string name;
    public Vector2 position;

    public RoomInfo()
    {

    }
    public RoomInfo(string name, Vector2 position)
    {
        this.name = name;
        this.position = position;
    }
}
