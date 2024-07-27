-> main
VAR hasReq = false
VAR hasBothReq = false
VAR doneReq = false

=== main ===

{
    - doneReq:
        -> neutral
    - hasBothReq:
        -> Req2
    - hasReq:
        -> yes
    - else:
        -> no
}
-> END

=== neutral ===
The greatest adventure is what lies ahead. #NPC
-> END

=== Req2 ===
Okay, the house is clear, you have your companions. Please tell me that’s it. #Player
I found it is the small everyday deeds of ordinary folk that keep the darkness at bay. #NPC
And I see the moral of these words before my very eyes. #NPC
Please, take these parts. #NPC
!! (I can use these for the ship!) #Player
May the wind under your wings bear you where the sun sails and the moon walks. #NPC

-> END

=== yes ===
Hey Gandalf. Your LARP going well or…? #Player
Be it companions or location, our world is incomplete. #NPC
But do not fret and do not weep. Even the smallest person can change the course of the future. #NPC
(Guess there’s something I’m missing.) #Player

-> END

=== no ===
#NPC
#Player
Hey! #Player
All we have to decide is what to do with the time that is given to us. #NPC
Er… #Player
I was talking aloud to myself. A habit of the old. #NPC
Who are you supposed to be? #Player
I am Gandalf the Grey and I am presently Live Action Role Playing. #NPC
A wizard is never late, nor is he early, he arrives precisely when he means to. But even the very wise cannot see all ends. #NPC
??? What’s up? #Player
My humble abode, invaded by some creature who misunderstands the old. Approach with caution and stealth. #NPC
I’ll… keep it in mind? #Player

-> END




=== function hasRequirement(int) ===
//1 is true
{
    - int == 1: 
          ~ hasReq = true
          
    - int == 2:
          ~ hasBothReq = true
      //anything else probably 0 is false
    - else:
          ~ hasReq = false
}