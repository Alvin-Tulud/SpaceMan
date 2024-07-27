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
Mmmmmm… sourdough… #NPC
-> END

=== yes ===
Hey Gator. #Player
Hello! #NPC
Wanna do something fun? There’s this block guy who wants to give you an interview. #Player
Ooo! #NPC
Should be right around… there. You got it? #Player
Yes, yes! #NPC
That’s not-- #Player
… the right way. #Player
(Well, they’ll find Sparkles eventually.) #Player



~doneReq = true
-> END

=== no ===
That’s new. #Player
Hello! #NPC
Hey. Nice suit. #Player
Thank you, thank you! #NPC
… #Player
… #NPC
Uhm, so what are you doing here? #Player
Hmm… #NPC
… #NPC
… #NPC
Dunno! #NPC
Cool. Good talk. #Player


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