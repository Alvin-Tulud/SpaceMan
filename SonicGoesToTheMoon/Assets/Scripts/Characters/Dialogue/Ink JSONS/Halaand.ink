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
LET’S BE OUR BEST. NOTHING SHORT. #NPC
-> END

=== yes ===
If you turn here and then turn there, you’ll see it. #Player
Thanks. *clears throat* I am ERIC HALLAND, BARBARIAN OF NORWAY. FEAR ME and my FOOTBALL. #NPC
(Wow. Didn’t know he had it in him.) #Player



~doneReq = true
-> END

=== no ===
West? … Or is it North? #NPC
Everything good? #Player
I don’t want to miss this chance. Gandalf invited me to LARP at his house after one of my games, but I can’t make sense of the maps he gave me. They just keep rotating. #NPC
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