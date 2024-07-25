using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickInteract : MonoBehaviour
{
    DoDialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = transform.parent.parent.GetComponent<DoDialogue>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator interactDone()
    {
        yield return new WaitForSeconds(0.5f);

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

        
    }

    private void toggleUIMove(bool can)
    {
        FindAnyObjectByType<PointAndClickMovement>().setCanMove(can);

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(!can);

        GetComponent<Button>().interactable = can;
    }
}
