// File: CustomerController
// Version: 1.0.1
// Last Updated: 2/6/19
// Authors: Alexander Jacks
// Description: Tells customer when and where to move

using UnityEngine;

public class CustomerController : MonoBehaviour
{
    public float speed;
    MoveSet ms;
    Queue<int> moveQ; // 0 = right, 1 = left, 2 = up, 3 = down, 4 = upright, 5 = upleft, 6 = downright, 7 = downleft

	void Start ()
    {
        ms = new MoveSet(transform, speed);
        moveQ = new Queue<int>(100);
        moveQ.enqueue(0, 6);
        moveQ.enqueue(3, 8);
        moveQ.enqueue(4, 4);
        moveQ.enqueue(5, 4);
        moveQ.enqueue(6, 4);
        moveQ.enqueue(7, 4);
        moveQ.enqueue(3, 5);
        moveQ.enqueue(1, 6);
        moveQ.enqueue(2, 14);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (ms.isMoving == -1)
        {
            if (!moveQ.isEmpty())
                ms.setMove(moveQ.peekAndDequeue(), ref moveQ);
        }
        else
            ms.move();
    }

    void think()
    {

    }
}
