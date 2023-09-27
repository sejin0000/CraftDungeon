using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class EnemyRoad : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Player;
    [SerializeField] private Tilemap Tilemap;
    private bool isDelay;

    private Node[,] grid;

    private enum Directions
    {
        Up = 0,
        Down,
        Left,
        Right,
        LeftUp,
        RightUp,
        LeftDown,
        RightDown,
    }

    private Vector3[] Vector3Directions = new Vector3[] {
        Vector3.up,
        Vector3.down,
        Vector3.left,
        Vector3.right,
        new Vector3(-1, 1, 0),
        new Vector3(1, 1, 0),
        new Vector3(-1, -1, 0),
        new Vector3(1, -1, 0)
    };
    public void Update()
    {
        if (isDelay == false)
        {
            isDelay = true;
            GetPosition();
            StartCoroutine(CallPosPerSecond());
        }
    }
    private void GetPosition()
    {
        Vector3 enemyPos = Enemy.transform.position;
        Vector3 playerPos = Player.transform.position;

        Debug.Log($"enemy : {Tilemap.WorldToCell(enemyPos)}");
        Debug.Log($"player : {Tilemap.WorldToCell(playerPos)}");
    }
    private void CreateGrid()        // grid 배열화
    {
        Tilemap.CompressBounds();
        BoundsInt bounds = Tilemap.cellBounds;
        grid = new Node[bounds.size.y, bounds.size.x];
        for (int y = bounds.yMin, i = 0; i < bounds.size.y; y++, i++)
        {
            for (int x = bounds.xMin, j = 0; j < bounds.size.x; x++, j++)
            {
                Node node = new Node();
                node.yIndex = i;
                node.xIndex = j;
                node.gCost = int.MaxValue;
                node.parent = null;
                node.yPos = Tilemap.CellToWorld(new Vector3Int(x, y)).y;
                node.xPos = Tilemap.CellToWorld(new Vector3Int(x, y)).x;
                // walkable 조건 : Tilemap에 타일이 있으면 이동 가능한 노드, 타일이 없으면 이동 불가능한 노드
                if (Tilemap.HasTile(new Vector3Int(x, y, 0)))
                {
                    node.isWalkable = true;
                    grid[i, j] = node;
                }
                else
                {
                    node.isWalkable = false;
                    grid[i, j] = node;
                }
            }
        }
    }

    public Node GetNodeFromPos(Vector3 position)
    {
        Vector3Int cellPos = Tilemap.WorldToCell(position);
        int y = cellPos.y + Mathf.Abs(Tilemap.cellBounds.yMin);
        int x = cellPos.x + Mathf.Abs(Tilemap.cellBounds.xMin);

        Node node = grid[y, x];
        return node;
    }

    // gcost : 시작 노드부터 현재 노드까지의 가중치
    // hcost : 현재 노트부터 끝 노드까지의 가중치
    // fcost : gcost + hcost
    private void GetNextNode(Node startNode, Node currentNode, Node endNode)
    {
        int newYindex;
        int newXindex;
        foreach ( Vector3 direction in Vector3Directions)
        {
            newYindex = (int)(currentNode.yIndex + direction.y);
            newXindex = (int)(currentNode.xIndex + direction.x);
            if (grid[newYindex,newXindex].isWalkable)
            {
                Node nextNode = grid[newYindex,newXindex];
                if (nextNode.parent == null)
                {
                    nextNode.xIndex = newXindex;
                    nextNode.yIndex = newYindex;
                    getCurrentNodeCost(startNode, nextNode, endNode);
                    nextNode.parent = currentNode;
                }
                //else if (nextNode.)
            }
        }
        
    }
    private void getCurrentNodeCost(Node startNode, Node currentNode, Node endNode)
    {
        currentNode.gCost = CalculateCost(startNode, currentNode);
        currentNode.hCost = CalculateCost(currentNode, endNode);
    }

    private int CalculateCost(Node startNode, Node endNode)
    {
        int xDiff = Mathf.Abs(startNode.xIndex - endNode.xIndex);
        int yDiff = Mathf.Abs(startNode.yIndex - endNode.yIndex);

        int diagonalCost = Mathf.Min(xDiff, yDiff) * 14;
        int straightCost = (Mathf.Max(xDiff, yDiff) - Mathf.Min(xDiff, yDiff)) * 10;

        return diagonalCost + straightCost;
    }


    IEnumerator CallPosPerSecond()
    {
        yield return new WaitForSeconds(1.0f);
        isDelay = false;
    }
}
