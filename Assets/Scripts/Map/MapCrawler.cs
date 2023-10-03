using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;
using System.Linq;

public class MapCrawler : MonoBehaviour
{
    public List<Vector2> visitedPositions = new List<Vector2> { new Vector2(0, 0) };

    // 4방향 딕셔너리
    private readonly Dictionary<Direction, Vector2> movementMapDirection = new Dictionary<Direction, Vector2>
    {
        { Direction.Top, Vector2.up},
        { Direction.Right, Vector2.right},
        { Direction.Left, Vector2.left},
        { Direction.Down, Vector2.down}
    };

    public List<Vector2> GenerateMap(MapGenerationData generationData)
    {
        int iterations = Random.Range(generationData.iterationMin, generationData.iterationMax);

        for(int i = 0; i < iterations; i++)
        {
            // 다음 룸의 좌표를 생성하되, 중복이 나오지 않을 때 까지 계속 생성
            // 이렇게 해도 되는건진 몰루....
            while (true)
            {
                Vector2 newPos = NextRoomPos(visitedPositions[Random.Range(0, visitedPositions.Count)]);

                if (!visitedPositions.Contains(newPos))
                {
                    visitedPositions.Add(newPos);

                    break;
                }
            }
        }

        return visitedPositions;
    }

    // 다음 맵의 좌표를 설정
    public Vector2 NextRoomPos(Vector2 prevPos)
    {
        Direction toMove = (Direction)Random.Range(0, movementMapDirection.Count);

        return prevPos += movementMapDirection[toMove]; 
    }
}
