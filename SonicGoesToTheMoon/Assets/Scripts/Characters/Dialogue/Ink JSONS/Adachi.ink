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
So you’re seriously counting on the party rouge, huh? #NPC
-> END

=== yes ===
I found him. He’s riiiight over there. #Player
… Let’s get this ball rolling. *clears throat* This quest pays a pretty penny, so I gotta get going. If anyone comes looking for a missing wallet, I wasn’t here. #NPC



~doneReq = true
-> END

=== no ===
Man, lost again. His drawings suck. #NPC
You good? #Player
No, Gandalf tried drawing maps to his house to go with the LARPing and all of the words keep moving. #NPC
(I can't read this chicken scratch, either.) #Player
I’ll let you know if I see him. #Player


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