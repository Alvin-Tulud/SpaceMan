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
    public float speed;

    // For keeping within the bounds of the game
    private Bounds cameraBounds;
    public Camera playerCamera;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        // Setup for the boundaries for the Camera
        var boundaries = GameObject.FindGameObjectWithTag("Floor").GetComponent<SpriteRenderer>().bounds;

        var height = playerCamera.orthographicSize;
        var width = height * playerCamera.aspect;

        var minX = boundaries.min.x + (width / 2);
        var maxX = boundaries.max.x - (width / 2);

        var minY = boundaries.min.x + (height / 2);
        var maxY = boundaries.max.y - (height / 2);

        cameraBounds = new Bounds();

        cameraBounds.SetMinMax(
            new Vector3(minX, minY, 0.0f),
            new Vector3(maxX, maxY, 0.0f)
        );

        // Debug for the boundaries
        Gizmos.color = Color.red;
        Gizmos.DrawLine(cameraBounds.min, cameraBounds.max);
    }


    void LateUpdate()
    {
        // var targetPosition = getWithinBounds(player.transform.position);

        var targetPosition = player.transform.position;
        targetPosition.z = -10;

        transform.position = targetPosition;
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
