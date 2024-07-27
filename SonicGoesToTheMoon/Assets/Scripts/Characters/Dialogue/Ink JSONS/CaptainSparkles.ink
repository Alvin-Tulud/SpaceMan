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
Should I ask about their diet? Maybe that’s too personal…. #NPC
-> END

=== yes ===
Hey, Captain. I got an idea for you. #Player
There’s this big green gator - they stand on their hind legs, wear a purple shirt, and talk! It would make for some good content. #Player
That would be great! I’m thinking an interview would do. #NPC
Could you find them again and tell them to meet me here? #NPC



~doneReq = true
-> END

=== no ===
Alright. What’s going on, dudes? It’s me, Captain Sparkles. Welcome to… uhm… #NPC
(Oh, he’s recording. Allllright, let’s just go around.) #Player
Ah, you there! #NPC
(Aw, dammit.) #Player
Excuse me! Sorry to interrupt you. One of my viewers suggested that I visit this place and film. #NPC
I’m a little lost, though, and I couldn’t find much online about the landmarks. #NPC
Yeah, we don’t leave much of a digital footprint. #Player
Ah, I’m hoping the video will help out the town with that. I’m sure there’s something good here.  #NPC
If you have any ideas, send them my way. #NPC


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