using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class rocketTakeOff : MonoBehaviour
{
    Vector3 initPos;
    Vector3 endPos;

    float currTime;
    float endTime;
    bool canTakeOff;
    bool notcalledyet;

    public GameObject SpaceAnim;
    Image RocketImg;
    DoDialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        endPos = transform.position + (Vector3.up * 7);

        currTime = 0;

        endTime = 250;

        canTakeOff = false;

        notcalledyet = false;

        SpaceAnim.SetActive(false);

        dialogue = GameObject.Find("Rocket").GetComponent<DoDialogue>();

        RocketImg = GetComponent<Image>();

        RocketImg.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (dialogue.getNeutral() && !notcalledyet)
        {
            takeOff();
            notcalledyet = true;
        }

        if (canTakeOff)
        {
            if (currTime <= endTime)
            {
                currTime++;
                transform.position = Vector3.Lerp(initPos, endPos, currTime / endTime);
            }
            else
            {
                SpaceAnim.SetActive(true);

                StartCoroutine(screenWait());
            }
        }
    }

    public void takeOff()
    {
        canTakeOff = true;
        RocketImg.enabled = true;

        GetComponent<ParticleSystem>().Play();

        GameObject.Find("PlayerGraphic").SetActive(false);
    }

    public IEnumerator screenWait()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
}
