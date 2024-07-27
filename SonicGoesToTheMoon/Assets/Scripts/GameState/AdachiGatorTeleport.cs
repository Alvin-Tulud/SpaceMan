using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdachiGatorTeleport : MonoBehaviour
{
    public DoDialogue dialogue;

    Vector3 v;
    // Start is called before the first frame update
    void Start()
    {
        //dialogue is set in the inspector
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue.getNeutral())
        {
            if(gameObject.name.CompareTo("Cool Gator") == 0)
            {
                v = new Vector3(-1.4f, 1.25f, 0);
            }
            else if (gameObject.name.CompareTo("Eric Haaland") == 0)
            {
                v = new Vector3(21.51f, 8.6f, 0);
            }
            else if(gameObject.name.CompareTo("Adachi") == 0)
            {
                v = new Vector3(24.46f, 8.58f, 0);
            }

            gameObject.transform.position = v;
        }
    }
}
