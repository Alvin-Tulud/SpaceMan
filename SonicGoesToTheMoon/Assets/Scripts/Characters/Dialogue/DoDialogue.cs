using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDialogue : MonoBehaviour
{
    public TextAsset inkAsset;
    private Story dialogue;

    public bool needInteract;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = new Story(inkAsset.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
