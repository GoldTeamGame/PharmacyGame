// File: Stack
// Version: 1.0.1
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Basic Stack

public class Stack<T>
{
    T[] q; // holds elements
    public int size; // current size of stack

    // Initialize variables
    public Stack(int size)
    {
        q = new T[size];
        this.size = 0;
    }

    // Add element to queue
    public void push(T element)
    {
        if (size < q.Length)
            q[size++] = element;
    }

    // Look at first element in queue
    public T peek()
    {
        if (size > 0)
            return q[size - 1];
        else
            return default(T);
    }

    // Extract first element from queue
    public T peekAndPop()
    {
        if (size > 0)
            return q[(size-- - 1)];
        else
            return default(T);
    }

    // Remove first element from queue
    public void pop()
    {
        if (size > 0)
            size--;
    }

    // Check to see if queue is empty
    public bool isEmpty()
    {
        return size == 0;
    }

    public string displayAll()
    {
        string elements = "";

        for (int i = 0; i < size; i++)
        {
            elements += q[i].ToString() + " ";
        }

        return elements;
    }
}
