using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;

public class Door : MonoBehaviour
{
    public DoorType doorType;
    public GameObject linkedRoom;

    public void SetLinkedRoom(GameObject room)
    {
        this.linkedRoom = room;
    }
}
