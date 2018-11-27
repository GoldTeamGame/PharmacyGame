using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour {
    
    public Tilemap tilemap; // the area the customer can explore
    public Sprite testSprite; // Debugging
    Vector3 location; // where the customer is in the Tilemap_Infrastructure Object
    Vector3 moveLocation;
    int isMoving;
    bool isLeaving;
    Queue q;

	// Use this for initialization
	void Start ()
    {
        isMoving = 0;
        isLeaving = false;
        //Tile t = new Tile();
        //t.sprite = testSprite;
        //tilemap.SetTile(new Vector3Int(-4, 5, 1), t);
        q = new Queue(100);

        q.enqueue("right");
        q.enqueue("right");
        q.enqueue("right");

        q.enqueue("down");
        q.enqueue("down");
        q.enqueue("down");
        q.enqueue("down");

        q.enqueue("downleft");
        q.enqueue("downleft");
        q.enqueue("downleft");

        q.enqueue("up");
        q.enqueue("up");
        q.enqueue("up");
        q.enqueue("up");
        q.enqueue("up");
        q.enqueue("up");
        q.enqueue("up");
        q.enqueue("up");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isMoving == 0)
        {
            if (!q.isEmpty())
                beginMove(q.peekAndDequeue());
        }
        else
            move();
    }

    void beginMove(string command)
    {
        int numberOfMoves = 1;
        while (!q.isEmpty() && q.peek().Equals(command))
        {
            numberOfMoves++;
            q.dequeue();
        }

        if (command.Equals("right"))
        {
            moveLocation = new Vector3(transform.localPosition.x + numberOfMoves, transform.localPosition.y, 1);
            if (moveLocation.x > tilemap.cellBounds.xMax)
                return;
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 1;
        }
        else if (command.Equals("left"))
        {
            moveLocation = new Vector3(transform.localPosition.x - numberOfMoves, transform.localPosition.y, 1);
            if (moveLocation.x < tilemap.cellBounds.xMin)
                return;
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 2;
        }
        else if (command.Equals("up"))
        {
            moveLocation = new Vector3(transform.localPosition.x, transform.localPosition.y + numberOfMoves, 1);
            if (moveLocation.y > tilemap.cellBounds.yMax)
            {
                if ((moveLocation.x >= -2 && moveLocation.x <= -1))
                    //Destroy(gameObject);
                    isLeaving = true;
                else
                    return;
            }
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 3;
        }
        else if (command.Equals("down"))
        {
            moveLocation = new Vector3(transform.localPosition.x, transform.localPosition.y - numberOfMoves, 1);
            if (moveLocation.y < tilemap.cellBounds.yMin)
                return;
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 4;
        }
        else if (command.Equals("upright"))
        {
            moveLocation = new Vector3(transform.localPosition.x + numberOfMoves, transform.localPosition.y + numberOfMoves, 1);
            if (moveLocation.x > tilemap.cellBounds.xMax || moveLocation.y > tilemap.cellBounds.yMax)
                return;
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 5;
        }
        else if (command.Equals("upleft"))
        {
            moveLocation = new Vector3(transform.localPosition.x - numberOfMoves, transform.localPosition.y + numberOfMoves, 1);
            if (moveLocation.x < tilemap.cellBounds.xMin || moveLocation.y > tilemap.cellBounds.yMax)
                return;
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 6;
        }
        else if (command.Equals("downright"))
        {
            moveLocation = new Vector3(transform.localPosition.x + numberOfMoves, transform.localPosition.y - numberOfMoves, 1);
            if (moveLocation.x > tilemap.cellBounds.xMax || moveLocation.y < tilemap.cellBounds.yMin)
                return;
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 7;
        }
        else if (command.Equals("downleft"))
        {
            moveLocation = new Vector3(transform.localPosition.x - numberOfMoves, transform.localPosition.y - numberOfMoves, 1);
            if (moveLocation.x < tilemap.cellBounds.xMin || moveLocation.y < tilemap.cellBounds.yMin)
                return;
            Debug.Log("Current Location: " + moveLocation.ToString());
            isMoving = 8;
        }
    }

    void move()
    {
        if (isMoving == 1)
        {
            if (transform.localPosition.x >= moveLocation.x)
            {
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(1, 0, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else if (isMoving == 2)
        {
            if (transform.localPosition.x <= moveLocation.x)
            {
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(-1, 0, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else if (isMoving == 3)
        {
            if (transform.localPosition.y >= moveLocation.y)
            {
                if (isLeaving)
                    Destroy(gameObject);
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(0, 1, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else if (isMoving == 4)
        {
            if (transform.localPosition.y <= moveLocation.y)
            {
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(0, -1, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else if (isMoving == 5)
        {
            if (transform.localPosition.x >= moveLocation.x)
            {
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(1, 0.95f, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else if (isMoving == 6)
        {
            if (transform.localPosition.x <= moveLocation.x)
            {
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(-1, 0.95f, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else if (isMoving == 7)
        {
            Debug.Log(moveLocation.ToString());
            if (transform.localPosition.x >= moveLocation.x)
            {
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(1, -0.95f, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
        else if (isMoving == 8)
        {
            if (transform.localPosition.x <= moveLocation.x)
            {
                isMoving = 0;
                transform.localPosition = moveLocation;
            }
            else
            {
                Vector3 move = new Vector3(-1, -0.95f, 0) * Time.deltaTime;
                transform.Translate(move);
            }
        }
    }

    class Queue
    {
        string[] q;
        int size;
        int head;

        public Queue(int size)
        {
            q = new string[size];
            this.size = 0;
            head = 0;
        }

        public void enqueue(string element)
        {
            q[size++] = element;
        }

        public string peek()
        {
            return q[head];
        }

        public string peekAndDequeue()
        {
            return q[head++];
        }

        public void dequeue()
        {
            head++;
        }

        public bool isEmpty()
        {
            return head >= size;
        }
    }
}
