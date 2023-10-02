using NativeSerializableDictionary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Map Generation Data", menuName = "Map Generation/Map Data")]
public class MapGenerationData : ScriptableObject
{
    public int numberOfCrawlers;
    public int iterationMin;
    public int iterationMax;

    public SerializableDictionary<string, GameObject> roomPrefabs = new SerializableDictionary<string, GameObject>();
}
