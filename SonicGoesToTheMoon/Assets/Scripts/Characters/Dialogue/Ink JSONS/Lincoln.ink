-> main
VAR hasReq = false
VAR doneReq = false

=== main ===

{
    - doneReq:
        -> neutral
    - hasReq:
        -> yes
    - else:
        -> no
}
-> END

=== neutral ===
… Did the address include this much about myself before? #NPC
-> END

=== yes ===
Mr. President, I come with good news. #Player
You found it. Many, many thanks, good sir. #NPC
… Hm, this looks different from what I remember. It’s no matter. Please, take these fruits. It’s the least I can do. #NPC
Watermelons, apples, starfruit… This is a lot. #Player
The local farmers gave me quite the haul, but I cannot take this much from the people. It’ll be in better hands with you. #NPC
I bid you an affectionate farewell. #NPC



~doneReq = true
-> END

=== no ===
No way, that’s… #Player
Good day, young sir. #NPC
Good day, President Lincoln. The weather is… good. #Player
Yes, I do agree but it may not be one I can enjoy. I apologize if this is sudden but, you see… I lost my copy of the Gettysburg Address. #NPC
Wow, sounds serious. #Player
I must agree and I would appreciate any help. I can only hope it’s located soon, because the Declaration of Independence-- #NPC
(I’m not sitting through this.) What does it begin with? #Player
Ah, yes. It should begin with… “Four score and seven years ago our fathers brought forth…” #NPC
If you find it, please let me know. #NPC


-> END




=== function hasRequirement(int) ===
//1 is true
{
    - int == 1: 
          ~ hasReq = true
      //anything else probably 0 is false
    - else:
          ~ hasReq = false
}