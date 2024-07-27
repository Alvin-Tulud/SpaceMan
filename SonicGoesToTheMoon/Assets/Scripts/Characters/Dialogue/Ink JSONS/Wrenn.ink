-> main
VAR hasReq = false
VAR doneReq = false

=== main ===
w: … #NPC
p: hey you good? #Player
p: (they cant hear me i guess. headphones must be blasting). #Player

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