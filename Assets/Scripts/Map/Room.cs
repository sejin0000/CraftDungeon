using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;

public class Room : MonoBehaviour
{
    public int width;
    public int height;

    public Vector2 roomPosition;

    public Door leftDoor;
    public Door rightDoor;
    public Door topDoor;
    public Door bottomDoor;

    public List<Door> doors = new List<Door>();

    private void Start()
    {
        if(MapCreator.Instance == null)
        {
            Debug.Log("No Instance MapCreator.cs");
            return;
        }
    }

    public void RemoveUnconnectedDoors()
    {
        foreach(Door door in doors)
        {
            switch (door.doorType)
            {
                case DoorType.Right:
                    if (GetRightRoom() == null)
                        door.gameObject.SetActive(false);
                    break;
                case DoorType.Left:
                    if (GetLeftRoom() == null)
                        door.gameObject.SetActive(false);
                    break;
                case DoorType.Top:
                    if (GetTopRoom() == null)
                        door.gameObject.SetActive(false);
                    break;
                case DoorType.Bottom:
                    if (GetBottomRoom() == null)
                        door.gameObject.SetActive(false);
                    break;
            }
        }
    }

    private Room GetRightRoom()
    {
        Vector2 roomPos = new Vector2(roomPosition.x + 1, roomPosition.y);

        if (MapCreator.Instance.DoesRoomExist(roomPos))
        {
            return MapCreator.Instance.FindRoom(roomPos);
        }
        else
            return null;
    }

    private Room GetLeftRoom()
    {
        Vector2 roomPos = new Vector2(roomPosition.x - 1, roomPosition.y);

        if (MapCreator.Instance.DoesRoomExist(roomPos))
        {
            return MapCreator.Instance.FindRoom(roomPos);
        }
        else
            return null;
    }

    private Room GetTopRoom()
    {
        Vector2 roomPos = new Vector2(roomPosition.x, roomPosition.y + 1);

        if (MapCreator.Instance.DoesRoomExist(roomPos))
        {
            return MapCreator.Instance.FindRoom(roomPos);
        }
        else
            return null;
    }

    private Room GetBottomRoom()
    {
        Vector2 roomPos = new Vector2(roomPosition.x, roomPosition.y - 1);

        if (MapCreator.Instance.DoesRoomExist(roomPos))
        {
            return MapCreator.Instance.FindRoom(roomPos);
        }
        else
            return null;
    }

    // ������ ǥ�� - ���� ���ֵ� ��
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    // ����Ⱦ�  ���� ����ִ� �� ���� �� ����
    public Vector2 GetRoomCenter()
    {
        return new Vector2(roomPosition.x * width, roomPosition.y * height);
    }
}
