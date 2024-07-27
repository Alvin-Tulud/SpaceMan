using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketTakeOff : MonoBehaviour
{
    Vector3 initPos;
    Vector3 endPos;

    float currTime;
    float endTime;
    bool canTakeOff;

    public GameObject SpaceAnim;
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        endPos = transform.position + (Vector3.up * 7);

        currTime = 0;

        endTime = 250;

        canTakeOff = false;

        SpaceAnim.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canTakeOff)
        {
            if (currTime <= endTime)
            {
                currTime++;
                Vector3.Lerp(initPos, endPos, currTime / endTime);
            }
            else
            {
                SpaceAnim.SetActive(true);
            }
        }
    }

    public void takeOff()
    {
        canTakeOff = true;
        GetComponent<ParticleSystem>().Play();
    }
}
