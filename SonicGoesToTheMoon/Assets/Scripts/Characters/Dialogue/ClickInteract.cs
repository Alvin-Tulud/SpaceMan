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

        if (interactbox.OverlapPoint(mousePos) && Input.GetMouseButtonDown(0))
        {
            //stop player movement and enable the dialogue box
            FindAnyObjectByType<PointAndClickMovement>().setCanMove(false);

            GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(true);

            dialogue.setTextBox(GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>());
        }

        if (!dialogue.getIsPlaying())
        {
            FindAnyObjectByType<PointAndClickMovement>().setCanMove(true);

            GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
