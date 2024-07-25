using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickInteract : MonoBehaviour
{
    Collider2D interactbox;

    DoDialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        interactbox = GetComponent<Collider2D>();
        dialogue = transform.parent.parent.GetComponent<DoDialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        //turn movement back on when they arent hovering and dialogue isnt playing
        if (dialogue != null && !dialogue.getIsPlaying())
        {
            //Debug.Log("not playing");
            interactDone();
        }
    }

    public void interactDone()
    {
        FindAnyObjectByType<PointAndClickMovement>().setCanMove(true);

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(false);

        GetComponent<Button>().interactable = true;
    }


    //if player clicks down while hovering the dialogue box start dialogue
    public void startdialogue()//button function
    {
        Debug.Log("clicked");

        FindAnyObjectByType<PointAndClickMovement>().setCanMove(false);

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(true);

        dialogue.setIsPlaying(true);

        dialogue.setTextBox(GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>());

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.AddListener(dialogue.tellStory);

        GetComponent<Button>().interactable = false;
    }
}
