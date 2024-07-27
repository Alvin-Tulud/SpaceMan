using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMonologue : MonoBehaviour
{
    public ClickInteract click;
    private bool hastalked;
    // Start is called before the first frame update
    void Start()
    {
        hastalked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hastalked)
        {
            hastalked = true;

            click.startdialogue();
        }
    }
}
