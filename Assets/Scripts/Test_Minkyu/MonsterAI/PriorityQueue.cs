using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class PriorityQueue
{
    private List<Node> heap;

    public int Count()
    {
        return heap.Count;
    }
    public PriorityQueue()
    {
        heap = new List<Node>();
    }

    public void Enqueue(Node item)       // 효율을 위해 적당한 위치에 삽입
    {
        heap.Add(item);
        int currentIdx = heap.Count - 1;

        while (currentIdx > 0)
        {
            int midIdx = (currentIdx - 1) / 2;
            if (heap[currentIdx].CompareTo(heap[midIdx]) >= 0 )
            {
                break;
            }

            Swap(currentIdx, midIdx);
            currentIdx = midIdx;
        }
    }

    public Node Dequeue()
    {
        Node item = heap[0];
        heap.RemoveAt(0);


        int currentIdx = 0;
        while (true)
        {
            int leftChildIdx = currentIdx * 2 + 1;
            int rightChildIdx = currentIdx * 2 + 2;
            int smallestIdx = currentIdx;

            if (leftChildIdx < heap.Count && heap[leftChildIdx].CompareTo(heap[smallestIdx]) < 0)
            {
                smallestIdx = leftChildIdx;
            }
            if (rightChildIdx < heap.Count && heap[rightChildIdx].CompareTo(heap[smallestIdx]) < 0)
            {
                smallestIdx = rightChildIdx;
            }
            if (smallestIdx == currentIdx)
            {
                break;
            }

            Swap(currentIdx, smallestIdx);
            currentIdx = smallestIdx;
        }

        return item;
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        Node temp = heap[firstIndex];
        heap[firstIndex] = heap[secondIndex];
        heap[secondIndex] = temp;
    }
}
