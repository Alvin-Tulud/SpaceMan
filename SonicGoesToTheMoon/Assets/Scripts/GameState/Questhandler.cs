using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questhandler : MonoBehaviour
{

    /* Haaland: Football
     * Nobara: Nothing
     * Homelander: Trophy
     * 
     * 
     * 
     */

    //Dict. for giving away items to npc's
    //Dict. for recieving items from npc's
    //Dict. for unlocking hasReq
    //Edge case for gandalf

    //***Look for 

    //Dictionary<>


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
     *  Gandalf gives 2nd item
     *  Else:
     *  Gandalf gives 1st item
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
}
