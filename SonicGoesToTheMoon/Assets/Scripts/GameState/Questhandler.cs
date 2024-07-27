using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //give me item(this guy);
    //Function for recieving items
    //pass in transform.name (string)

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
     *  Gandalf recieves 1st item
     * 
     */

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
    
    //Function for removing item to inv.
    //(both of these call render function)

    //Function for re-rendering inv.
    //for[i 0-3]:
    //if [inv.size-1 >= i]:
    //  update sprite
    //else
    //  empty sprite
}
