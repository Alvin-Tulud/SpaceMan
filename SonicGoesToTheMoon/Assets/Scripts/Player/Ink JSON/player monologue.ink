-> main
VAR hasReq = false
VAR doneReq = false

=== main ===
… #player
I’m gonna say it: this place is a lost cause. #player
The roads here suck, oxygen is expensive, and the locals don’t even CARE about the environment. We have to deal with constant temperature anomalies, astronomical storms, and magnetic tornadoes. Then they go around and say climate change isn’t REAL??? #player
In a day, this planet is going to be hit with the worst storms to date. #player
And you know what, I’m not gonna be here to see it. #player
I’m getting out of here. To a safer planet with a better climate AND free oxygen. The grass is always greener on the other side, but at least there’ll BE grass. #player
I still need a plan, though. Something I can do in a day. #player
Hmm… Maybe there are spaceship parts I can find to escape. #player
The people here are ignorant, but they explore more than me. Let’s see if they have anything. #player

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