using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class EnemyRoad : MonoBehaviour
{
    [SerializeField] private GameObject Enemy;
    [SerializeField] private GameObject Player;
    [SerializeField] private Tilemap Tilemap;
    private bool isDelay;

    private Node[,] grid;

    private PriorityQueue OpenedSet;
    private List<Node> ClosedSet;

    private List<Node> Route = new List<Node>();


    private Rigidbody2D _rigidbody;

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
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        CreateGrid();
        //PathFinding();

    }
    private void Update()
    {
        if (isDelay == false)
        {
            isDelay = true;
            GetPosition();
            PathFinding();
            Route = GetPath(Enemy.transform.position, Player.transform.position);
            StartCoroutine(CallPosPerSecond());
        }
    }

    private void FixedUpdate()
    {
        if (Route.Count == 0)
            return;
        
        if (GetNodeFromPos(Enemy.transform.position) != Route[0])
        {
            Vector3 _moveDirection = (new Vector3(Route[0].xPos, Route[0].yPos, transform.position.z) - new Vector3(GetNodeFromPos(Enemy.transform.position).xPos, GetNodeFromPos(Enemy.transform.position).yPos, 0)).normalized;
            _rigidbody.MovePosition(_rigidbody.position + new Vector2(_moveDirection.x, _moveDirection.y) * 5 * Time.fixedDeltaTime);
        }
        else
        {
            Route.RemoveAt(0);
        }
    }
    private void GetPosition()
    {
        Vector3 enemyPos = Enemy.transform.position;
        Vector3 playerPos = Player.transform.position;

        Debug.Log($"enemy : {Tilemap.WorldToCell(enemyPos)}, [{GetNodeFromPos(enemyPos).xIndex}, {GetNodeFromPos(enemyPos).yIndex}]");
        Debug.Log($"player : {Tilemap.WorldToCell(playerPos)}, [{GetNodeFromPos(playerPos).xIndex}, {GetNodeFromPos(playerPos).yIndex}]");
    }

    private Vector3 GetDiffBetweenGridNPos(Vector3 objectPos)
    {
        Vector3Int objectCellPos = Tilemap.WorldToCell(objectPos);
        return objectPos - Tilemap.GetCellCenterWorld(objectCellPos);
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
    private void PathFinding()
    {
        Vector3 startPos = Enemy.transform.position;
        Vector3 startDiffPos = GetDiffBetweenGridNPos(startPos);
        Vector3 endPos = Player.transform.position;
        Vector3 endDiffPos = GetDiffBetweenGridNPos(endPos);
        List<Node> path = GetPath(startPos, endPos);
        if (path != null)
        {
            for (int i = 0; i < path.Count; i++)
            {
                Debug.Log($"[{path[i].xIndex}, {path[i].yIndex}]");
            }

            for (int i = 0; i < path.Count - 1; i++)
            {
                if (i == 0)
                {
                    Vector3Int cellPos = Tilemap.WorldToCell(new Vector3(path[i].xPos, path[i].yPos));
                    Vector3 cellCenterPos = Tilemap.GetCellCenterWorld(cellPos) - Tilemap.cellGap / 2;
                    Debug.DrawLine(startPos, cellCenterPos - startDiffPos, Color.red, 5f);
                }
                if (i == path.Count - 2)
                {
                    Vector3Int cellPos = Tilemap.WorldToCell(new Vector3(path[i].xPos, path[i].yPos));
                    Vector3 cellCenterPos = Tilemap.GetCellCenterWorld(cellPos) - Tilemap.cellGap / 2;
                    Debug.DrawLine(cellCenterPos - startDiffPos, endPos, Color.red, 5f);
                }
                else
                {
                    Vector3Int startCellPos = Tilemap.WorldToCell(new Vector3(path[i].xPos, path[i].yPos));
                    Vector3 startCellCenterPos = Tilemap.GetCellCenterWorld(startCellPos) - Tilemap.cellGap / 2;
                    Vector3Int endCellPos = Tilemap.WorldToCell(new Vector3(path[i + 1].xPos, path[i + 1].yPos));
                    Vector3 endCellCenterPos = Tilemap.GetCellCenterWorld(endCellPos) - Tilemap.cellGap / 2;
                    Debug.DrawLine(startCellCenterPos - startDiffPos, endCellCenterPos - startDiffPos, Color.red, 5f);
                }
            }
        }

        foreach (Node node in grid)
        {
            node.parent = null;
        }
    }
    private List<Node> GetPath(Vector3 startPos, Vector3 endPos)
    {
        OpenedSet = new PriorityQueue();
        ClosedSet = new List<Node>();
        Node startNode = GetNodeFromPos(startPos);
        Node currentNode = GetNodeFromPos(startPos);
        Node endNode = GetNodeFromPos(endPos);
        getCurrentNodeCost(startNode, currentNode, endNode);
        OpenedSet.Enqueue(currentNode);

        while (OpenedSet.Count() > 0)
        {
            GetNextNode(startNode, currentNode, endNode, OpenedSet);
            currentNode = OpenedSet.Dequeue();
            ClosedSet.Add(currentNode);

            if (currentNode.xIndex == endNode.xIndex && currentNode.yIndex == endNode.yIndex)
            {
                List<Node> ansPath = new List<Node>();
                Node ansNode = currentNode;
                ansPath.Add(ansNode);
                while (ansNode.xIndex != startNode.xIndex || ansNode.yIndex != startNode.yIndex)
                {
                    if (Math.Abs(ansNode.xPos - ansNode.parent.xPos) == 1 && Math.Abs(ansNode.yPos - ansNode.parent.yPos) == 1)
                    {
                        if (grid[ansNode.parent.yIndex, ansNode.xIndex].isWalkable)
                        {
                            ansPath.Add(grid[ansNode.parent.yIndex, ansNode.xIndex]);
                        }
                        else
                        {
                            ansPath.Add(grid[ansNode.yIndex, ansNode.parent.xIndex]);
                        }
                    }
                    ansPath.Add(ansNode.parent);
                    ansNode = ansNode.parent;
                }
                ansPath.Add(startNode);
                ansPath.Reverse();
                return ansPath;
            }
        }
        return null;
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
    private void GetNextNode(Node startNode, Node currentNode, Node endNode, PriorityQueue prQueue)
    {
        int newYindex;
        int newXindex;
        foreach ( Vector3 direction in Vector3Directions)
        {
            newYindex = (int)(currentNode.yIndex + direction.y);
            newXindex = (int)(currentNode.xIndex + direction.x);
            try
            {
                if (grid[newYindex, newXindex].isWalkable)
                {
                    Node nextNode = grid[newYindex, newXindex];
                    if (nextNode.parent == null)
                    {
                        nextNode.xIndex = newXindex;
                        nextNode.yIndex = newYindex;
                        getCurrentNodeCost(startNode, nextNode, endNode);
                        nextNode.parent = currentNode;
                        prQueue.Enqueue(nextNode);
                    }
                }
            }
            catch
            {
                continue;
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
