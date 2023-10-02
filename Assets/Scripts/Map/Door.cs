using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;

public class Door : MonoBehaviour
{
    public DoorType doorType;
    public Room linkedRoom;

    public void SetLinkedRoom(Room room)
    {
        this.linkedRoom = room;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManagerM.Instance.cameraFollow.SetTarget(linkedRoom.transform);

            WarpPlayer(this.doorType, collision.gameObject);
        }
    }

    // 테스트용. 플레이어 스크립트 완성된 후 변경합니다.
    private void WarpPlayer(DoorType doorType, GameObject player)
    {
        switch (doorType)
        {
            case DoorType.Left:
                player.transform.position = new Vector3(linkedRoom.rightDoor.transform.position.x - 1,
                    player.transform.position.y, player.transform.position.z);
                break;
            case DoorType.Right:
                player.transform.position = new Vector3(linkedRoom.leftDoor.transform.position.x + 1,
                    player.transform.position.y, player.transform.position.z);
                break;
            case DoorType.Top:
                player.transform.position = new Vector3(player.transform.position.x,
                    linkedRoom.bottomDoor.transform.position.y + 1, player.transform.position.z);
                break;
            case DoorType.Bottom:
                player.transform.position = new Vector3(player.transform.position.x,
                    linkedRoom.topDoor.transform.position.y - 1, player.transform.position.z);
                break;
        }
    }
}
