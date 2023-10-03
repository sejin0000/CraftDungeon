using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeSerializableDictionary;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class MapCreator : MonoBehaviour
{
    private static MapCreator instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static MapCreator Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }


    [SerializeField]
    private MapCrawler mapCrawler;

    private const float BONUS_ROOM_RATE = 15f;

    [SerializeField]
    private MapGenerationData _mapGenerationData;

    private List<Vector2> mapRooms;

    public List<Room> loadedRooms = new List<Room>();

    /*
    private RoomInfo _currentLoadRoomData;

    private bool isSpawnedBossRoom;
    private bool isUpdatedRooms;
    */

    /*
    [SerializeField]
    private SerializableDictionary<string, GameObject> _roomPrefabs = new SerializableDictionary<string, GameObject>();
    */
    private void Start()
    {
        mapRooms = mapCrawler.GenerateMap(_mapGenerationData);
        SpawnRooms(mapRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2> rooms)
    {
        string stage = "Stage1";

        foreach(Vector2 roomLocation in rooms)
        {
            // 시작룸은 고정룸
            if(roomLocation == Vector2.zero)
            {
                LoadRoom(new RoomInfo(string.Concat(stage, "_Normal1"), Vector2.zero));

                // 테스트용
                GameManager.Instance.cameraFollow.SetTarget(loadedRooms[0].transform);
                GameManager.Instance.currentRoom = loadedRooms[0];
                loadedRooms[0].isClear = true;

                continue;
            }

            string roomNum = string.Concat("_Normal", Random.Range(1, _mapGenerationData.roomPrefabs.Count-2));
            string roomName = string.Concat(stage, roomNum);

            if ((roomLocation == mapRooms[mapRooms.Count - 1]) && (roomLocation != Vector2.zero))
            {
                LoadRoom(new RoomInfo(string.Concat(stage, "_Boss"), roomLocation));
            }
            else if((roomLocation == mapRooms[mapRooms.Count - 2]) && (roomLocation != Vector2.zero))
            {
                //임시로 보스방 근처에 생성되게 했습니다
                LoadRoom(new RoomInfo(string.Concat(stage, "_Shop"), roomLocation));
                loadedRooms[loadedRooms.Count - 1].isClear = true;
            }
            else
            {
                if (Gacha(BONUS_ROOM_RATE))
                {
                    LoadRoom(new RoomInfo(string.Concat(stage, "_Bonus"), roomLocation));
                    loadedRooms[loadedRooms.Count - 1].isClear = true;
                }
                else
                {
                    LoadRoom(new RoomInfo(roomName, roomLocation));
                }
            }
        }

        RemoveRoomDoor();
    }

    private bool Gacha(float rate)
    {
        if (Random.Range(1f, 101f) <= rate)
        {
            return true;
        }
        else
            return false;
    }

    public void LoadRoom(RoomInfo newRoom)
    {
        Room room = Instantiate(_mapGenerationData.roomPrefabs[newRoom.name]).GetComponent<Room>();
        room.roomPosition = newRoom.position;
        room.transform.position = new Vector3(newRoom.position.x * room.width, newRoom.position.y * room.height);

        loadedRooms.Add(room);
    }

    public void RemoveRoomDoor()
    {
        foreach(Room room in loadedRooms)
        {
            room.RemoveUnconnectedDoors();
        }
    }

    // 좌표로 룸이 있는지 확인
    public bool DoesRoomExist(Vector2 position)
    {
        return mapRooms.Find(roomPos => roomPos == position) != null;
    }

    public Room FindRoom(Vector2 position)
    {
        return loadedRooms.Find(room => room.roomPosition == position);
    }
}
