using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;

public class Door : MonoBehaviour
{
    private const float WARP_OFFSET = 1.2f;

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
            if (!GameManager.Instance.currentRoom.isClear)
                return;

            GameManager.Instance.OnPlayerMoveRoom(linkedRoom);

            WarpPlayer(this.doorType, collision.gameObject);
        }
    }

    // 테스트용. 플레이어 스크립트 완성된 후 변경합니다.
    private void WarpPlayer(DoorType doorType, GameObject player)
    {
        switch (doorType)
        {
            case DoorType.Left:
                player.transform.position = new Vector3(linkedRoom.rightDoor.transform.position.x - WARP_OFFSET,
                    player.transform.position.y, player.transform.position.z);
                break;
            case DoorType.Right:
                player.transform.position = new Vector3(linkedRoom.leftDoor.transform.position.x + WARP_OFFSET,
                    player.transform.position.y, player.transform.position.z);
                break;
            case DoorType.Top:
                player.transform.position = new Vector3(player.transform.position.x,
                    linkedRoom.bottomDoor.transform.position.y + WARP_OFFSET, player.transform.position.z);
                break;
            case DoorType.Bottom:
                player.transform.position = new Vector3(player.transform.position.x,
                    linkedRoom.topDoor.transform.position.y - WARP_OFFSET, player.transform.position.z);
                break;
        }
    }
}
