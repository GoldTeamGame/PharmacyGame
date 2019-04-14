﻿// File: PriorityQueue
// Version: 1.0.1
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Queue that pushes items with higher goodness values to the front

public class PriorityQueue
{
    Node[] q; // holds elements
    public int size; // current size of queue
    public int head; // first element in queue

    // Initialize variables
    public PriorityQueue(int size)
    {
        q = new Node[size];
        this.size = 0;
        head = 0;
    }

    // Add element to queue
    public void enqueue(Node element)
    {
        if (size + 1 >= q.Length)
        {
            int i = 0;
            for (; i + head < size; i++)
            {
                q[i] = q[i + head];
            }
            head = 0;
            size = i;
        }
        q[size++] = element;

        // Push newly added item up if it has a better (lower) goodness value
        int j = size - 1;
        while (j > head && q[j].goodness < q[j-1].goodness)
        {
            Node temp = q[j];
            q[j] = q[j - 1];
            q[j - 1] = temp;
            j--;
        }
    }

    // Look at first element in queue
    public Node peek()
    {
        return q[head];
    }

    // Extract first element from queue
    public Node peekAndDequeue()
    {
        return q[head++];
    }

    // Remove first element from queue
    public void dequeue()
    {
        head++;
    }

    // Check to see if queue is empty
    public bool isEmpty()
    {
        return head >= size;
    }

    public string displayAll()
    {
        string elements = "";

        for (int i = head; i < size; i++)
        {
            elements += q[i].goodness.ToString() + " ";
        }

        return elements;
    }
}