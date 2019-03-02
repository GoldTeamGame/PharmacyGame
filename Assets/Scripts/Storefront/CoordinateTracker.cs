// File: CoordinateTracker
// Version: 1.0.1
// Last Updated: 2/28/19
// Authors: Alexander Jacks
// Description: Figures out where mouse/finger click/tap occured on the tilemap (place script on tilemap)

using UnityEngine;

public class CoordinateTracker : MonoBehaviour
{
    static Transform t;

    public void Start()
    {
        t = transform;
    }

    public static Vector3 getMousePosition()
    {
        float x = Mathf.Floor(t.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).x) + .5f;
        float y = Mathf.Floor(t.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).y) + .5f;

        // These 2 will get the location of every half tile
        //float x = Mathf.Round(t.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).x * 2) / 2;
        //float y = Mathf.Round(t.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).y * 2) / 2;

        //Debug.Log("X: " + x + ", Y: " + y);
        return new Vector3(x, y);
    }

    // DEBUGGING
    //public void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        float x = Mathf.Round(t.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).x * 2) / 2;
    //        float y = Mathf.Round(t.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)).y * 2) / 2;
    //        //Debug.Log("X: " + x + ", Y: " + y);
    //    }
    //}
}
