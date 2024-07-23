using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerNear : MonoBehaviour
{
    Transform playerPos;
    Transform InteractVisual;
    private const float INTERACT_DISTANCE = 4f;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        InteractVisual = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerPos.position, transform.position) <= INTERACT_DISTANCE)
        {
            InteractVisual.gameObject.SetActive(true);
        }
        else
        {
            InteractVisual.gameObject.SetActive(false);
        }
    }
}
