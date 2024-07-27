using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    //THIAS IS THE SCRIPT THAT DOES NOTHING BUT
    //OPEN AND CLOSE THE INVENTORY WHEN YOU RIGHT CLICK
    //trying to get back into the flow of things with something that should be very simple and easy to do

    private bool invEnabled;
    private GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        //it starts disabled in the scene so, you know,
        invEnabled = false;

        inventory = GameObject.FindWithTag("Inventory").transform.GetChild(0).gameObject;
        inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //If the inventory is open, close it
            if(invEnabled)
            {
                invEnabled = false;
                inventory.SetActive(false);
            }
            //If it's closed, open it
            else
            {
                invEnabled = true;
                inventory.SetActive(true);
            }

        }
    }
}
