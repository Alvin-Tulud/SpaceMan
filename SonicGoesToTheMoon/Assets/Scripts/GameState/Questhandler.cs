using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questhandler : MonoBehaviour
{

    /* Dict <string, gameobj>
     * Dict Giving
     * Haaland: none
     * Nobara: rocket part bottom
     * Homelander: gettysburg address
     * Gandalf: rocket part top
     * Lincoln: watermelon
     * Gator: none
     * Adachi: none
     * Captain Sparkles: none
     * 
     * Dict <string, gameobj>
     * Dict Recieving
     * Haaland: none
     * Nobara: watermelon
     * Homelander: none
     * Gandalf: none
     * Lincoln: gettysburg address
     * Gator: none
     * Adachi: none
     * Captain Sparkles: none
     * 
     * Dict <string, DoDialogue>
     * Dict DoDialogue
     * Haaland: DoDialogue
     * Nobara: DoDialogue
     * Homelander: DoDialogue
     * Gandalf: DoDialogue
     * Lincoln: DoDialogue
     * Gator: DoDialogue
     * Adachi: DoDialogue
     * Captain Sparkles: DoDialogue
     */

    //Dict. for giving away items to npc's
    //Dict. for recieving items from npc's
    //Dict. for unlocking hasReq
    //Edge case for gandalf

    //***Look for 

    //Dictionary<>

    //Inventory stuff (Sorry for putting everything in 1 script. I did what I had to do)

    //The inventory itself
    public List<string> playerInv;

    //Inventory slots, accessible in order to change their sprites
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;
    public GameObject slot4;

    //The sprites the inventory slots will change to
    public Sprite rocketBottom;
    public Sprite rocketTop;
    public Sprite gettysburg;
    public Sprite watermelon;
    public Sprite emptySlot;

    Dictionary<string, string> givingToPlayer;
    Dictionary<string, string> takingFromPlayer;

    public List<DoDialogue> dialogueList;

    // Start is called before the first frame update
    void Start()
    {
        //Create the dictionaries

        //dictionary for npc's giving items to the player
        givingToPlayer = new Dictionary<string, string>()
        {
            {"Nobara Kugisaki", "rocketBottom"},
            {"Homelander", "gettysburg"},
            {"Gandalf", "rocketTop"},
            {"Lincoln", "watermelon"}
        };

        //dictionary for npc's taking items from player
        takingFromPlayer = new Dictionary<string, string>()
        {
            {"Nobara Kugisaki", "watermelon"},
            {"Lincoln", "gettysburg"}
        };
    }

    // Update is called once per frame
    void Update()
    {
        foreach(DoDialogue dialogue in dialogueList)
        {
            //check for taking
            if (dialogue.transform.name == "Nobara Kugisaki" && dialogue.getHasTalked()  && takeFromPlayer("watermelon"))
            {
                dialogue.setHasReq(true);
            }
            else if (dialogue.transform.name == "Lincoln" && dialogue.getHasTalked() && takeFromPlayer("gettysburg"))
            {
                dialogue.setHasReq(true);
            }

            //general interactions
            else if (dialogue.transform.name == "Eric Haaland" && dialogue.getHasTalked() && GameObject.Find("Gandalf").GetComponent<DoDialogue>().getHasTalked())
            {
                dialogue.setHasReq(true);
            }
            else if (dialogue.transform.name == "Adachi" && dialogue.getHasTalked() && GameObject.Find("Gandalf").GetComponent<DoDialogue>().getHasTalked())
            {
                dialogue.setHasReq(true);
            }
            else if (dialogue.transform.name == "Captain Sparkles" && dialogue.getHasTalked() && GameObject.Find("Cool Gator").GetComponent<DoDialogue>().getHasTalked())
            {
                dialogue.setHasReq(true);
            }
            else if (dialogue.transform.name == "Cool Gator" && dialogue.getHasTalked() && GameObject.Find("Captain Sparkles").GetComponent<DoDialogue>().getHasTalked())
            {
                dialogue.setHasReq(true);
            }
            else if (dialogue.transform.name == "Gandalf" && dialogue.getHasTalked() && GameObject.Find("Cool Gator").GetComponent<DoDialogue>().getHasReq() && GameObject.Find("Captain Sparkles").GetComponent<DoDialogue>().getHasReq())
            {
                dialogue.setHasReq(true);

                if (dialogue.transform.name == "Gandalf" && dialogue.getHasTalked() && GameObject.Find("Adachi").GetComponent<DoDialogue>().getHasReq() && GameObject.Find("Eric Haaland").GetComponent<DoDialogue>().getHasReq())
                {
                    dialogue.setHasBothReq(true);
                }
            }
            else if (dialogue.transform.name == "Gandalf" && dialogue.getHasTalked() && GameObject.Find("Adachi").GetComponent<DoDialogue>().getHasReq() && GameObject.Find("Eric Haaland").GetComponent<DoDialogue>().getHasReq())
            {
                dialogue.setHasReq(true);

                if (dialogue.transform.name == "Gandalf" && dialogue.getHasTalked() && GameObject.Find("Cool Gator").GetComponent<DoDialogue>().getHasReq() && GameObject.Find("Captain Sparkles").GetComponent<DoDialogue>().getHasReq())
                {
                    dialogue.setHasBothReq(true);
                }
            }
        }
    }

    //Function for NPC giving the player items. Gives them item based on the player.
    //pass in transform.name (string)
    public void giveToPlayer(string name)
    {
        //Only give if the NPC has something to give
        if (givingToPlayer.ContainsKey(name) == true)
        {
            Debug.Log("give: " + name);
            string itemToGive = givingToPlayer[name];
            addItem(itemToGive);
        }
    }

    //Function for giving items
    /* 1. Look up character in dictionary
     * 
     *  *****
     * 
     * 2. Give them the item
     * 
     *  *****IF GANDALF:
     *  If script.getHasReq(true): 
     *  Gandalf recieves 2nd item
     *  Else:
     *  Gandalf recieves 1st item?
     * 
     */

    //Function for NPC taking the player's item. Takes an item based on who the NPC is.
    public bool takeFromPlayer(string name)
    {
        //Only take if the NPC has something to take
        if(takingFromPlayer.ContainsKey(name)==true)
        {
            string itemToTake = takingFromPlayer[name];
            removeItem(itemToTake);

            return true;
        }

        return false;
    }

    //Function for checking quest req.
    //pass in script
    /*  Idea:  [barring special case for gandalf]
     *  checkReq(the script itself) {
     *  
     *  Prep:
     *  1. Get hasReq from the script
     *  2. Get the character from the script's parent
     *  
     *  
     *  3. Use THIS script's dictionary to look up the character's requirements
     *  4. Check player inventory to see if they have the required item
     * 
     * If true, double check for gandalf
     */




    //Function for adding item to inv.
    //THE ONLY VALID INPUT STRINGS ARE rocketBottom | rocketTop | gettysburg | watermelon
    public void addItem(string item)
    {
        playerInv.Add(item);
        renderInventory();
    }

    //Function for removing item to inv.
    //THE ONLY VALID INPUT STRINGS ARE rocketBottom | rocketTop | gettysburg | watermelon
    public void removeItem(string item)
    {
        playerInv.Remove(item);
        renderInventory();
    }

    //Function for re-rendering inv.
    //for[i 0-3]:
    //if [inv.size-1 >= i]:
    //  update sprite
    //else
    //  empty sprite
    public void renderInventory()
    {
        GameObject slot;
        for(int i=0; i<3; i++)
        {
            //Determine what slot we are trying to affect
            //brain is fried Rn and this is the easiest way for me to look at it
            if(i==0)
            {
                slot = slot1;
            }
            else if(i==1)
            {
                slot = slot2;
            }
            else if (i == 2)
            {
                slot = slot3;
            }
            else
            {
                slot = slot4;
            }

            //Only check for sprite from inv if the inv is big enough
            if (playerInv.Count-1 >= i)
            {
                //manually change sprite based on item
                if(playerInv[i] == "watermelon")
                {
                    slot.GetComponent<Image>().sprite = watermelon;
                }
                else if (playerInv[i] == "gettysburg")
                {
                    slot.GetComponent<Image>().sprite = gettysburg;
                }
                else if (playerInv[i] == "rocketTop")
                {
                    slot.GetComponent<Image>().sprite = rocketTop;
                }
                else if (playerInv[i] == "rocketBottom")
                {
                    slot.GetComponent<Image>().sprite = rocketBottom;
                }

            }

            //Rest of the slots will be default
            else
            {
                slot.GetComponent<Image>().sprite = emptySlot;
            }
        }
    }
}
