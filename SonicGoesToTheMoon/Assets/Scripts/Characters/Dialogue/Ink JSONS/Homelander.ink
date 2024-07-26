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
        -> yes
}
-> END

=== neutral ===
H: You still need something monkey? #NPC
P: … #Player
P: (Let’s get out of here.) #Player

-> END

=== yes ===
P: Hey. #Player
H: You. Read this now. #NPC
P: “Four score and seven years ago our fathers brought forth…” You wrote this? #Player
H: What? Think I’m incapable? #NPC
P: … #Player
H: Hah. #NPC
H: I wrote this entire speech, but if you recognized anything from whatever history lessons they taught you in school, you would know that it’s inspired by the words of our forefathers. #NPC
H: The Gettysburg Address. President Lincoln. Spoke of great liberty and equality among the people. Any bells ringing in that little head? #NPC
P: Oh, uhm yeah. #Player
H: Changing your tune? Of course, of course. What would I expect? #NPC
H: You know what, hold onto that copy. Read it once, then again, and if you can’t recite it by tomorrow… Well, you wouldn’t want to see, would you? #NPC
P: Ahaha, yeah, I gotcha. #Player
P: (I gotta get out of here.) #Player



~doneReq = true
-> END

=== no ===
#NPC
#Player

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