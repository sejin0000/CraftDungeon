using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;

public class RoomInfo
{
    public RoomType roomType;

    public string name;
    public Vector2 position;

    public RoomInfo()
    {

    }
    public RoomInfo(string name, Vector2 position, RoomType roomType)
    {
        this.name = name;
        this.position = position;
        this.roomType = roomType;
    }
}
