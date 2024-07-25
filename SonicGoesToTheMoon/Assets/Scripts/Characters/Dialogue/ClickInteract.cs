using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickInteract : MonoBehaviour
{
    Collider2D col;
    DoDialogue dialogue;

    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        col = GetComponent<Collider2D>();
        dialogue = transform.parent.parent.GetComponent<DoDialogue>();

        if (col.OverlapPoint(mousePos))
        {
            FindAnyObjectByType<PointAndClickMovement>().setCanMove(false);
        }
        else if (!col.OverlapPoint(mousePos) && !dialogue.getIsPlaying())
        {
            FindAnyObjectByType<PointAndClickMovement>().setCanMove(true);
        }
    }

    public IEnumerator interactDone()
    {
        yield return new WaitForSeconds(1f);

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();

        toggleUIMove(true);
    }


    //if player clicks down while hovering the dialogue box start dialogue
    public void startdialogue()//button function
    {
        dialogue.setIsPlaying(true);
        Debug.Log("clicked: " + transform.parent.parent.name);

        toggleUIMove(false);

        dialogue.setTextBox(GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>());

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.AddListener(dialogue.tellStory);

        dialogue.tellStory();
    }

    private void toggleUIMove(bool can)
    {
        FindAnyObjectByType<PointAndClickMovement>().setCanMove(can);

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(!can);

        GetComponent<Button>().interactable = can;
    }
}
