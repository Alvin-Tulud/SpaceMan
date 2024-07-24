using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClickInteract : MonoBehaviour
{
    Collider2D interactbox;
    Vector2 mousePos;

    DoDialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        interactbox = GetComponent<Collider2D>();
        dialogue = transform.parent.GetComponent<DoDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (interactbox.OverlapPoint(mousePos))
        {
            //stop player movement and enable the dialogue box
            FindAnyObjectByType<PointAndClickMovement>().setCanMove(false);

            if (Input.GetMouseButtonDown(0))
            {
                GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(true);

                dialogue.setTextBox(GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>());
            }
        }
        //else
        //{
        //    FindAnyObjectByType<PointAndClickMovement>().setCanMove(false);
        //}
    }
}
