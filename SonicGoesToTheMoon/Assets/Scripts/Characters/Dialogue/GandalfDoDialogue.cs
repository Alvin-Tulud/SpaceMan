using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GandalfDoDialogue : MonoBehaviour
{
    public TextAsset inkAsset;
    private Story dialogue;
    private TextMeshProUGUI dialogueTextBox;
    private ClickInteract clickInteract;

    private Button button;

    public bool needInteract;
    public bool hasReq1;
    public bool hasReq2;
    public string charAudio = "event:/SFX/UI/dialogeProgress";
    private bool isPlaying;
    private bool doOnce = true;
    private int dialogueCounter = 0;
    // Start is called before the first frame update
    void Awake()
    {
        dialogue = new Story(inkAsset.text);

        isPlaying = false;

        clickInteract = transform.GetChild(0).GetChild(0).GetComponent<ClickInteract>();
    }

    public void setTextBox(TextMeshProUGUI text)
    {
        dialogueTextBox = text;

        dialogue.ResetState();
    }

    public void tellStory()
    {
        if (dialogue.canContinue)
        {
            Debug.Log("play");
            isPlaying = true;
            if (needInteract)
            {
                if (hasReq1 && !hasReq2)
                {
                    var returnValue = dialogue.EvaluateFunction("hasRequirement", 1);
                }
                else if (hasReq2)
                {
                    var returnValue = dialogue.EvaluateFunction("hasRequirement", 2);
                }
                else
                {
                    var returnValue = dialogue.EvaluateFunction("hasRequirement", 0);
                }
            }


            string text = dialogue.Continue();


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
            if (doOnce)
            {
                StartCoroutine(clickInteract.interactDone());
                doOnce = false;
                dialogueCounter = 0;
            }
        }
    }

    public void setHasReq1(bool hasReq) { this.hasReq1 = hasReq; }

    public void setHasReq2(bool hasReq) { this.hasReq2 = hasReq; }

    public bool getIsPlaying() { return isPlaying; }

    public void setIsPlaying(bool isPlaying) { this.isPlaying = isPlaying; }

    //public bool getDoOnce(bool doOnce) { return doOnce; }

    public void resetDoOnce() { doOnce = true; }
}
