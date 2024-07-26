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
You still need something monkey? #NPC
… #Player
(Let’s get out of here.) #Player

-> END

=== yes ===
Hey. #Player
You. Read this now. #NPC
“Four score and seven years ago our fathers brought forth…” You wrote this? #Player
What? Think I’m incapable? #NPC
… #Player
Hah. #NPC
I wrote this entire speech, but if you recognized anything from whatever history lessons they taught you in school, you would know that it’s inspired by the words of our forefathers. #NPC
The Gettysburg Address. President Lincoln. Spoke of great liberty and equality among the people. Any bells ringing in that little head? #NPC
Oh, uhm yeah. #Player
Changing your tune? Of course, of course. What would I expect? #NPC
You know what, hold onto that copy. Read it once, then again, and if you can’t recite it by tomorrow… Well, you wouldn’t want to see, would you? #NPC
Ahaha, yeah, I gotcha. #Player
(I gotta get out of here.) #Player



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