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
    }

    public IEnumerator interactDone()
    {
        yield return new WaitForSeconds(1f);

        SFX.PlayOneShot("event:/SFX/UI/dialogeClose");

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.RemoveAllListeners();

        toggleUIMove(true);

        dialogue.resetDoOnce();

        StartCoroutine(stopspam());
    }


    //if player clicks down while hovering the dialogue box start dialogue
    public void startdialogue()//button function
    {
        dialogue.setIsPlaying(true);

        SFX.PlayOneShot("event:/SFX/UI/dialogeStart");
        Debug.Log("clicked: " + transform.parent.parent.name);

        toggleUIMove(false);

        dialogue.setTextBox(GameObject.FindWithTag("DialogueText").GetComponent<TextMeshProUGUI>(), GameObject.FindWithTag("DialogueName").GetComponent<TextMeshProUGUI>(), GameObject.FindWithTag("DialogueImage").GetComponent<Image>());

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).GetComponent<Button>().onClick.AddListener(dialogue.tellStory);

        dialogue.tellStory();
    }

    private void toggleUIMove(bool can)
    {
        FindAnyObjectByType<PointAndClickMovement>().setCanMove(can);

        GameObject.FindWithTag("DialogueBox").transform.GetChild(0).gameObject.SetActive(!can);

        GetComponent<Button>().interactable = can;
    }

    public IEnumerator stopspam()
    {
        GetComponent<Button>().interactable = false;
        yield return new WaitForSeconds(4f);
        GetComponent<Button>().interactable = true;
    }
}
