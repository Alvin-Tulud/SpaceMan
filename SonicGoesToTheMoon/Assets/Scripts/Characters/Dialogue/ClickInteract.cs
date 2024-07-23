using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInteract : MonoBehaviour
{
    Collider2D interactbox;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        interactbox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (interactbox.OverlapPoint(mousePos) && Input.GetMouseButtonDown(0))
        {
            //stop player movement and enable the dialogue box
            FindAnyObjectByType<AIPath>().canMove = false;

            GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
