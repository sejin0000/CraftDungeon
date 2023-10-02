using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeSerializableDictionary;
using UnityEngine.UIElements;

public class MapCreator : Singleton<MapCreator>
{
    /*
    public Dictionary<int, List<Vector2>> downPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2),   new Vector2(-1, -2),   new Vector2(-1, -1) } }, // ㅁ
        {  1, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2),    new Vector2(1, -2)                        } }, // └
        {  2, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2),    new Vector2(-1, -2)                       } }, // ┛
        {  3, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2)                                               } }, // |
        {  4, new List<Vector2>      { new Vector2(0, -1),   new Vector2(-1, -1)                                              } }, // left ㅡ 
        {  5, new List<Vector2>      { new Vector2(0, -1),   new Vector2(1, -1)                                               } }, // right ㅡ
        {  6, new List<Vector2>      { new Vector2(0, -1)                                                                     } }, // single
    };

    public Dictionary<int, List<Vector2>> upPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2),   new Vector2(-1, 2),   new Vector2(-1, 1)     } }, // ㅁ
        {  1, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2),    new Vector2(-1, 2)                          } }, // ┐
        {  2, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2),    new Vector2(1, 2)                           } }, // ┏
        {  3, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2)                                                 } }, // |
        {  4, new List<Vector2>      { new Vector2(0, 1),   new Vector2(-1, 1)                                                } }, // left ㅡ 
        {  5, new List<Vector2>      { new Vector2(0, 1),   new Vector2(1, 1)                                                 } }, // right ㅡ
        {  6, new List<Vector2>      { new Vector2(0, 1)                                                                      } }, // single
    };

    public Dictionary<int, List<Vector2>> leftPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0),   new Vector2(-2, -1),   new Vector2(-1, -1) } }, // ㅁ
        {  1, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0),    new Vector2(-2, 1)                        } }, // └
        {  2, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0),    new Vector2(-2, -1)                       } }, // ┌
        {  3, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0)                                               } }, // ㅡ
        {  4, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-1, 1)                                               } }, // up ㅣ 
        {  5, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-1, -1)                                              } }, // down ㅣ
        {  6, new List<Vector2>      { new Vector2(-1, 0)                                                                     } }, // single
    };

    public Dictionary<int, List<Vector2>> rightPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0),   new Vector2(2, 1),   new Vector2(1, 1) } }, // ㅁ
        {  1, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0),    new Vector2(2, 1)                           } }, // ┛
        {  2, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0),    new Vector2(2, -1)                          } }, // ┐
        {  3, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0)                                                 } }, // ㅡ
        {  4, new List<Vector2>      { new Vector2(1, 0),   new Vector2(1, 1)                                                 } }, // up ㅣ 
        {  5, new List<Vector2>      { new Vector2(1, 0),   new Vector2(1, -1)                                                } }, // down ㅣ
        {  6, new List<Vector2>      { new Vector2(1, 0)                                                                      } }, // single
    };
    */

    [SerializeField]
    private MapGenerationData _mapGenerationData;

    private List<Vector2> mapRooms;

    public int minRoomCount = 0;
    public int maxRoomCount = 0;

    public List<Room> loadedRooms = new List<Room>();

    private RoomInfo _currentLoadRoomData;

    private bool isSpawnedBossRoom;
    private bool isUpdatedRooms;

    [SerializeField]
    private SerializableDictionary<string, GameObject> _roomPrefabs = new SerializableDictionary<string, GameObject>();

    private void Start()
    {
        mapRooms = MapCrawler.Instance.GenerateMap(_mapGenerationData);
        SpawnRooms(mapRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2> rooms)
    {
        string stage = "Stage1";

        foreach(Vector2 roomLocation in rooms)
        {
            if(roomLocation == Vector2.zero)
            {
                LoadRoom(new RoomInfo(string.Concat(stage, "_Normal1"), Vector2.zero));

                // 테스트용
                GameManager.Instance.cameraFollow.SetTarget(loadedRooms[0].transform);

                continue;
            }

            string roomNum = string.Concat("_Normal", Random.Range(1, _roomPrefabs.Count));
            string roomName = string.Concat(stage, roomNum);

            Debug.Log(roomName);

            if ((roomLocation == mapRooms[mapRooms.Count - 1]) && (roomLocation != Vector2.zero))
            {
                LoadRoom(new RoomInfo(string.Concat(stage, "_Boss"), new Vector2(roomLocation.x, roomLocation.y)));
            }
            else
            {
                LoadRoom(new RoomInfo(roomName, new Vector2(roomLocation.x, roomLocation.y)));
            }
        }

        RemoveRoomDoor();
    }

    public void LoadRoom(RoomInfo newRoom)
    {
        Room room = Instantiate(_roomPrefabs[newRoom.name]).GetComponent<Room>();
        room.roomPosition = newRoom.position;
        room.transform.position = new Vector3(newRoom.position.x * room.width, newRoom.position.y * room.height);

        //room.RemoveUnconnectedDoors();

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
