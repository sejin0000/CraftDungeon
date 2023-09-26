using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeSerializableDictionary;
using UnityEngine.UIElements;

public class MapCreator : Singleton<MapCreator>
{
    public Dictionary<int, List<Vector2>> downPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2),   new Vector2(-1, -2),   new Vector2(-1, -1) } }, // ¤±
        {  1, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2),    new Vector2(1, -2)                        } }, // ¦¦
        {  2, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2),    new Vector2(-1, -2)                       } }, // ¦°
        {  3, new List<Vector2>      { new Vector2(0, -1),   new Vector2(0, -2)                                               } }, // |
        {  4, new List<Vector2>      { new Vector2(0, -1),   new Vector2(-1, -1)                                              } }, // left ¤Ñ 
        {  5, new List<Vector2>      { new Vector2(0, -1),   new Vector2(1, -1)                                               } }, // right ¤Ñ
        {  6, new List<Vector2>      { new Vector2(0, -1)                                                                     } }, // single
    };

    public Dictionary<int, List<Vector2>> upPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2),   new Vector2(-1, 2),   new Vector2(-1, 1)     } }, // ¤±
        {  1, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2),    new Vector2(-1, 2)                          } }, // ¦¤
        {  2, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2),    new Vector2(1, 2)                           } }, // ¦®
        {  3, new List<Vector2>      { new Vector2(0, 1),   new Vector2(0, 2)                                                 } }, // |
        {  4, new List<Vector2>      { new Vector2(0, 1),   new Vector2(-1, 1)                                                } }, // left ¤Ñ 
        {  5, new List<Vector2>      { new Vector2(0, 1),   new Vector2(1, 1)                                                 } }, // right ¤Ñ
        {  6, new List<Vector2>      { new Vector2(0, 1)                                                                      } }, // single
    };

    public Dictionary<int, List<Vector2>> leftPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0),   new Vector2(-2, -1),   new Vector2(-1, -1) } }, // ¤±
        {  1, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0),    new Vector2(-2, 1)                        } }, // ¦¦
        {  2, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0),    new Vector2(-2, -1)                       } }, // ¦£
        {  3, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-2, 0)                                               } }, // ¤Ñ
        {  4, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-1, 1)                                               } }, // up ¤Ó 
        {  5, new List<Vector2>      { new Vector2(-1, 0),   new Vector2(-1, -1)                                              } }, // down ¤Ó
        {  6, new List<Vector2>      { new Vector2(-1, 0)                                                                     } }, // single
    };

    public Dictionary<int, List<Vector2>> rightPatten = new Dictionary<int, List<Vector2>>
    {
        {  0, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0),   new Vector2(2, 1),   new Vector2(1, 1) } }, // ¤±
        {  1, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0),    new Vector2(2, 1)                           } }, // ¦°
        {  2, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0),    new Vector2(2, -1)                          } }, // ¦¤
        {  3, new List<Vector2>      { new Vector2(1, 0),   new Vector2(2, 0)                                                 } }, // ¤Ñ
        {  4, new List<Vector2>      { new Vector2(1, 0),   new Vector2(1, 1)                                                 } }, // up ¤Ó 
        {  5, new List<Vector2>      { new Vector2(1, 0),   new Vector2(1, -1)                                                } }, // down ¤Ó
        {  6, new List<Vector2>      { new Vector2(1, 0)                                                                      } }, // single
    };

    public int minRoomCount = 0;
    public int maxRoomCount = 0;

    public List<Room> loadedRooms = new List<Room>();

    private RoomInfo _currentLoadRoomData;

    [SerializeField]
    private SerializableDictionary<string, GameObject> _roomPrefabs = new SerializableDictionary<string, GameObject>();

    private void Start()
    {
        LoadRoom(new RoomInfo("Test", new Vector2(0, 0)));
        LoadRoom(new RoomInfo("Test", new Vector2(1, 0)));
        LoadRoom(new RoomInfo("Test", new Vector2(-1, 0)));
        LoadRoom(new RoomInfo("Test", new Vector2(0, 1)));
        LoadRoom(new RoomInfo("Test", new Vector2(0, -1)));
    }

    public void LoadRoom(RoomInfo newRoom)
    {
        if (DoesRoomExist(newRoom.position))
            return;

        /*
        RoomInfo newRoomData = new RoomInfo();
        newRoomData.name = newRoom.name;
        newRoomData.position = newRoom.position;
        */

        Room room = Instantiate(_roomPrefabs[newRoom.name]).GetComponent<Room>();
        room.roomPosition = newRoom.position;
        room.transform.position = new Vector3(newRoom.position.x * room.width, newRoom.position.y * room.height);

        loadedRooms.Add(room);
    }

    // ÁÂÇ¥·Î ·ëÀÌ ÀÖ´ÂÁö È®ÀÎ
    public bool DoesRoomExist(Vector2 position)
    {
        return loadedRooms.Find(room => room.roomPosition.x == position.x && room.roomPosition.y == position.y) != null;
    }
}
