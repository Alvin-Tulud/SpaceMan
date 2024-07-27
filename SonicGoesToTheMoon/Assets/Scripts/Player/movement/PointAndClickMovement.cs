using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickMovement : MonoBehaviour
{
    public AIDestinationSetter destinationSystem;
    private GameObject destinationPointer;
    private bool canMove;
    [SerializeField] CanvasGroup blackBackgrondFade;


    // Start is called before the first frame update
    void Start()
    {
        destinationPointer = new GameObject("destinationPointer");
        destinationPointer.transform.position = transform.position;

        canMove = true;
        Sounds.StartMusic("event:/Music/Main");
        blackBackgrondFade.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove)
        {
            // Get clicked on location in world space ...
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = transform.position.z;


            // Set the empty gameObject to the location as well as the Astar target
            destinationPointer.transform.position = mousePosition;
            destinationSystem.target = destinationPointer.transform;

            // Debug.Log("Moving to " + mousePosition.x + "," + mousePosition.y);
        }
    }

    public void setCanMove(bool canMove)
    {
        //Debug.Log(canMove);
        this.canMove = canMove;
    }

    IEnumerator FadeIn()
    {
        float timeElapsed = 0;
        float lerpTime = .5f;
        while (timeElapsed < lerpTime)
        {
            blackBackgrondFade.alpha = Mathf.Lerp(1, 0, timeElapsed / lerpTime);
            timeElapsed += Time.deltaTime;
            yield return null;

        }
    }
}