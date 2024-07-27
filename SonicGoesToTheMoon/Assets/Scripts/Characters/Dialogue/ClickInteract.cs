using Pathfinding;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickInteract : MonoBehaviour
{
    Collider2D col;
    DoDialogue dialogue;

    public string charAudio = "event:/SFX/UI/dialogeStart";

    Vector2 mousePos;

    bool stopspam;
    int maxtime;
    int currtime;
    // Start is called before the first frame update
    void Start()
    {
        stopspam = false;
        currtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        col = GetComponent<Collider2D>();
        dialogue = transform.parent.parent.GetComponent<DoDialogue>();
    }

    private void FixedUpdate()
    {
        if (stopspam)
        {
            GetComponent<Button>().interactable = false;
            currtime++;

            if (currtime >= maxtime)
            {
                stopspam = false;
                GetComponent<Button>().interactable = true;
            }
        }
    }

    public IEnumerator interactDone()
    {
        yield return new WaitForSeconds(1.5f);

        Sounds.PlayOneShot("event:/SFX/UI/dialogeClose");

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();

        toggleUIMove(true);

        dialogue.resetDoOnce();

        if (GetComponent<Button>() != null)
        {
            currtime = 0;
            stopspam = true;
        }
    }


    //if player clicks down while hovering the dialogue box start dialogue
    public void startdialogue()//button function
    {
        dialogue.setIsPlaying(true);

        Sounds.PlayOneShot(charAudio);
        Debug.Log("clicked: " + transform.parent.parent.name);

        toggleUIMove(false);

        dialogue.setTextBox(GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>(), GameObject.FindWithTag("DialogueName").GetComponent<TextMeshProUGUI>(), GameObject.FindWithTag("DialogueImage").GetComponent<Image>());

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.AddListener(dialogue.tellStory);

        dialogue.tellStory();
    }

    private void toggleUIMove(bool can)
    {
        FindAnyObjectByType<PointAndClickMovement>().setCanMove(can);

        FindAnyObjectByType<AIPath>().canMove = can;

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(!can);

        if (GetComponent<Button>() != null)
        {
            GetComponent<Button>().interactable = can;
        }
    }
}
