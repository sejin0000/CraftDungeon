using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public int width;
    public int height;

    public Vector2 roomPosition;

    private void Start()
    {
        if(MapCreator.Instance == null)
        {
            Debug.Log("No Instance MapCreator.cs");
            return;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    public Vector2 GetRoomCenter()
    {
        return new Vector2(roomPosition.x * width, roomPosition.y * height);
    }
}
