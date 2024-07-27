using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdachiGatorTeleport : MonoBehaviour
{
    public DoDialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        //dialogue is set in the inspector
        Vector3 v;
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogue.getNeutral())
        {
            if(gameObject.name.CompareTo("Cool Gator") == 0)
            {
                v = new Vector3()
            }
            else if (gameObject.name.CompareTo("Eric Haaland") == 0)
            {

            }
            else if(gameObject.name.CompareTo("Adachi") == 0)
            {

            }
        }
    }
}
