using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

        //turn off movement while play is hovering interact button
        if (interactbox.OverlapPoint(mousePos))
        {
            FindAnyObjectByType<PointAndClickMovement>().setCanMove(false);

            //if player clicks down while hovering the dialogue box start dialogue
            if (Input.GetMouseButtonDown(0))
            {
                GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(true);

                dialogue.setIsPlaying(true);

                dialogue.setTextBox(GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>());

                GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.AddListener(dialogue.tellStory);
            }
        }
        //turn movement back on when they arent hovering and dialogue isnt playing
        if (!dialogue.getIsPlaying())
        {
            //Debug.Log("not playing");
            interactDone();
        }
    }

    public void interactDone()
    {
        FindAnyObjectByType<PointAndClickMovement>().setCanMove(true);

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(false);
    }
}
