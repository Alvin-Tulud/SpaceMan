using Ink.Runtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoDialogue : MonoBehaviour
{
    public TextAsset inkAsset;
    private Story dialogue;
    private TextMeshProUGUI dialogueTextBox;
    private TextMeshProUGUI dialogueName;
    private Image dialogueImage;
    private ClickInteract clickInteract;

    private string NpcName;
    public Sprite NpcImage;
    private string PlayerName;
    public Sprite PlayerImage;

    private Button button;

    public bool needInteract;
    public bool hasReq;
    private bool hasBothReq;
    private bool hasTalked;
    private bool hasGiven;
    private bool neutral;
    private bool isPlaying;
    private bool doOnce = true;
    private int dialogueCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Story(inkAsset.text);


        isPlaying = false;
        hasTalked = false;
        hasGiven = false;
        neutral = false;


        NpcName = transform.name;
        PlayerName = GameObject.FindWithTag("Player").transform.name;


        clickInteract = transform.GetChild(0).GetChild(0).GetComponent<ClickInteract>();
    }

    public void setTextBox(TextMeshProUGUI text, TextMeshProUGUI name, Image headshot)
    {
        dialogueTextBox = text;
        dialogueName = name;
        dialogueImage = headshot;
    }

    public void tellStory()
    {
        if (dialogue.canContinue)
        {
            //text logic
            Debug.Log("play: " + transform.name);
            isPlaying = true;
            
            if (needInteract)
            {
                //check if has req();

                if (neutral)
                {
                    var returnValue = dialogue.variablesState["doneReq"] = true;
                }
                else if (hasBothReq && hasTalked)
                {
                    var returnValue = dialogue.EvaluateFunction("hasRequirement", 2);
                }
                else if (hasReq && hasTalked)
                {
                    var returnValue = dialogue.EvaluateFunction("hasRequirement", 1);
                }
                else
                {
                    var returnValue = dialogue.EvaluateFunction("hasRequirement", 0);
                }
            }

            //get all data from continue
            string text = dialogue.Continue();


            //do visuals first
            List<string> tags = dialogue.currentTags;
            if (tags[0].CompareTo("NPC") == 0)
            {
                dialogueName.text = NpcName;
                dialogueImage.sprite = NpcImage;
            }
            else
            {
                dialogueName.text = PlayerName;
                dialogueImage.sprite = PlayerImage;
            }

            //display text

            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            dialogueTextBox.text = text;
            if (dialogueCounter != 0)
            {
                Sounds.PlayOneShot("event:/SFX/UI/dialogeProgress");
            }
            dialogueCounter++;

        }
        else
        {
            //Debug.Log("done");
            isPlaying = false;
            hasTalked = true;


            if (doOnce)
            {
                dialogue.ResetState();
                StartCoroutine(clickInteract.interactDone());
                doOnce = false;
                dialogueCounter = 0;

                if (hasReq && hasTalked && !hasGiven)
                {
                    Questhandler q = FindAnyObjectByType<Questhandler>();
                    //q.takeFromPlayer(gameObject.name);
                    q.giveToPlayer(gameObject.name);
                    neutral = true;

                    hasGiven = true;
                }
            }
        }
    }

    public void setHasReq(bool hasReq) { this.hasReq = hasReq; }

    public bool getHasReq() { return hasReq; }

    public void setHasBothReq(bool hasReq) { this.hasBothReq = hasReq; }

    public bool getHasBothReq() { return hasBothReq; }

    public bool getIsPlaying() { return isPlaying; }

    public void setIsPlaying(bool isPlaying) { this.isPlaying = isPlaying; }

    public void setHasTalked(bool hasTalked) { this.hasTalked = hasTalked; }

    public bool getNeutral() { return neutral; }

    public bool getHasTalked() { return hasTalked; }


    //public bool getDoOnce(bool doOnce) { return doOnce; }

    public void resetDoOnce() { doOnce = true; }


}
