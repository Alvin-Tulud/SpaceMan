using Ink.Runtime;
using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoDialogue : MonoBehaviour
{
    public TextAsset inkAsset;
    private Story dialogue;
    private TextMeshProUGUI dialogueTextBox;

    private Button button;

    public bool needInteract;
    private bool hasReq;
    private bool isPlaying;
    // Start is called before the first frame update
    void Awake()
    {
        dialogue = new Story(inkAsset.text);
    }

    public void setTextBox(TextMeshProUGUI text)
    {
        dialogueTextBox = text;
    }

    public void tellStory()
    {
        if(dialogue.canContinue)
        {
            if (hasReq)
            {
                var returnValue = dialogue.EvaluateFunction("hasRequirement", 1);
            }
            else
            {
                var returnValue = dialogue.EvaluateFunction("hasRequirement", 0);
            }


            string text = dialogue.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            dialogueTextBox.text = text;
        }
    }

    public void setHasReq(bool hasReq) { this.hasReq = hasReq; }
}
