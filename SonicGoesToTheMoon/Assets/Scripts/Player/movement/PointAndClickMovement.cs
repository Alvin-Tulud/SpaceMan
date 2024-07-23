using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickMovement : MonoBehaviour
{
    public AIDestinationSetter destinationSystem;
    private GameObject destinationPointer;

    // Start is called before the first frame update
    void Start()
    {
        destinationPointer = new GameObject("destinationPointer");
        destinationPointer.transform.position = transform.position;
    }

   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get clicked on location in world space ...
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;


            // Set the empty gameObject to the location as well as the Astar target
            destinationPointer.transform.position = mousePosition;
            destinationSystem.target = destinationPointer.transform;

            Debug.Log("Moving to " + mousePosition.x + "," + mousePosition.y);

        }
    }
}
