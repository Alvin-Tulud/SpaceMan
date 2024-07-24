using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PACCameraMovement : MonoBehaviour
{
    // For moving with the player
    private GameObject player;

    // For keeping within the bounds of the game
    private Bounds floorBounds;
    private Bounds cameraBounds;
    public Camera playerCamera;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Setup for the boundaries for the Camera
        floorBounds = GameObject.FindGameObjectWithTag("ProperFloor").GetComponent<SpriteRenderer>().bounds;

        var height = playerCamera.orthographicSize;
        var width = height * playerCamera.aspect;

        var minX = floorBounds.min.x + width;
        var maxX = floorBounds.max.x - width;

        var minY = floorBounds.min.y + height;
        var maxY = floorBounds.max.y - height;

        cameraBounds = new Bounds();

        cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
        );
    }


    void LateUpdate()
    {
        // Set new location within the bounds of the game
        var targetPosition = getWithinBounds(player.transform.position);

        // Backup Code to follow the player
        //var targetPosition = player.transform.position;
        //targetPosition.z = -10;

        transform.position = targetPosition;

        // Debug for the boundaries
        /*Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.min.x, floorBounds.min.y,0), Color.blue);
        Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.min.x, floorBounds.max.y, 0), Color.blue);
        Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.max.x, floorBounds.min.y, 0), Color.blue);
        Debug.DrawLine(floorBounds.center, new Vector3(floorBounds.max.x, floorBounds.max.y, 0), Color.blue);

        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.min.x, cameraBounds.min.y, 0), Color.red);
        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.min.x, cameraBounds.max.y, 0), Color.red);
        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.max.x, cameraBounds.min.y, 0), Color.red);
        Debug.DrawLine(cameraBounds.center, new Vector3(cameraBounds.max.x, cameraBounds.max.y, 0), Color.red);*/
        
    }

    private Vector3 getWithinBounds(Vector3 positionInGame)
    {
        return new Vector3(
            Mathf.Clamp(positionInGame.x, cameraBounds.min.x, cameraBounds.max.x),
            Mathf.Clamp(positionInGame.y, cameraBounds.min.y, cameraBounds.max.y),
            transform.position.z
        );
    }
}
