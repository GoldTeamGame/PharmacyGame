// File: Queue
// Version: 1.0.3
// Last Updated: 2/7/19
// Authors: Alexander Jacks
// Description: Basic Queue

public class Queue<T>
{
    T[] q; // holds elements
    int size; // current size of queue
    int head; // first element in queue

    // Initialize variables
    public Queue(int size)
    {
        q = new T[size];
        this.size = 0;
        head = 0;
    }

    // Add element to queue
    public void enqueue(T element)
    {
        q[size++] = element;
    }

    // Add x number of element to queue
    public void enqueue(T element, int numberOfElements)
    {
        for (int i = 0; i < numberOfElements; i++)
            q[size++] = element;
    }

    // Look at first element in queue
    public T peek()
    {
        return q[head];
    }

    // Extract first element from queue
    public T peekAndDequeue()
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
}
