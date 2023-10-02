using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IComparable<Node>
{
    public float xPos;
    public float yPos;
    public int xIndex;
    public int yIndex;

    public float hCost;
    public float gCost;

    public float fCost
    {
        get { return gCost + hCost; }
    }

    public Node parent;
    public bool isWalkable;

    public Node()
    {
        xPos = -1;
        yPos = -1;
        xIndex = -1;
        yIndex = -1;
        hCost = 0;
        gCost = 0;
        parent = null;
    }

    public void Reset()
    {
        hCost = 0;
        gCost = int.MaxValue;
        parent = null;
    }

    public Node CopyNode()
    {
        Node node = new Node();
        node.xPos = this.xPos;
        node.yPos = this.yPos;
        node.xIndex = this.xIndex;
        node.yIndex = this.yIndex;
        node.hCost = this.hCost;
        node.gCost = this.gCost;
        node.parent = this.parent;
        node.isWalkable = this.isWalkable;
        return node;
    }

    public int CompareTo(Node compareNode)
    {
        if (this.fCost < compareNode.fCost)
        {
            return -1;
        }
        else if (this.fCost > compareNode.fCost)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
