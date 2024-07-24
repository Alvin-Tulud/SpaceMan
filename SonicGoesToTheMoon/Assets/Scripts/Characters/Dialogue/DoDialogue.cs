using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoDialogue : MonoBehaviour
{
    public TextAsset inkAsset;
    private Story dialogue;
    private TextMeshProUGUI dialogueTextBox;

    public bool needInteract;
    private bool isPlaying;
    // Start is called before the first frame update
    void Awake()
    {
        dialogue = new Story(inkAsset.text);
    }

    // Update is called once per frame
    void Update()
    {
        tellStory();
    }

    public void setTextBox(TextMeshProUGUI text)
    {
        dialogueTextBox = text;
    }

    private void tellStory()
    {
        if(dialogue.canContinue)
        {
            string text = dialogue.Continue();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            dialogueTextBox.text = text;
        }
    }
}
