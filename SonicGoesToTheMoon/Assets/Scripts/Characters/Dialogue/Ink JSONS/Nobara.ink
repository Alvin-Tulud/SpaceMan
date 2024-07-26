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
*munch munch munch, crunch crunch crunch* #NPC
-> END

=== yes ===
I got something. #Player
Hey, is that… WATERMELON?!?!!? #NPC
In the flesh. All this for the small price of some metal. #Player
Ohhh. #NPC
(!! She grabbed one and broke it with her bare hands!) #Player
*munch munch* Oh, this hits the SPOT. #NPC
So, about that metal piece… #Player
Knock yourself out. *crunch crunch crunch* #NPC


~doneReq = true
-> END

=== no ===
… #Player
… #NPC
You don’t look so good. #Player
Ach, hey! Who asked for your opinion? #NPC
(Nobody, but you look terrible even by the standards of this town.) #Player
Sorry, sorry. Just concerned. #Player
Well, save it for yourself. I spent all day lugging a huge piece of metal here to trade, but no one even wants it. Now I’m tired, dirty, and I haven’t eaten ALL day! #NPC
I’ll trade with you. Just give me a min. #Player
Hm, alright. Find something worth my while. #NPC

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