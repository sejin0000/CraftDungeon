using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnumManager;
using System.Linq;

public class MapCrawler : MonoBehaviour
{
    public List<Vector2> visitedPositions = new List<Vector2> { new Vector2(0, 0) };

    // 4���� ��ųʸ�
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
            // ���� ���� ��ǥ�� �����ϵ�, �ߺ��� ������ ���� �� ���� ��� ����
            // �̷��� �ص� �Ǵ°��� ����....
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

    // ���� ���� ��ǥ�� ����
    public Vector2 NextRoomPos(Vector2 prevPos)
    {
        Direction toMove = (Direction)Random.Range(0, movementMapDirection.Count);

        return prevPos += movementMapDirection[toMove]; 
    }
}
