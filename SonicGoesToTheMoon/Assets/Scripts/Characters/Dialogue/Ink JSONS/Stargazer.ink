-> main
VAR hasReq = false
VAR doneReq = false

=== main ===
Why is the moon so bright? #NPC
That’s easy to answer, it should be because-- #Player
Because it’s going through a phase! #NPC
… #Player

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

-> END

=== yes ===



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