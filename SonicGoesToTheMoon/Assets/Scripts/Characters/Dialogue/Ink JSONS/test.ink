-> main
VAR hasReq = false

=== main ===
Once upon a time... 

balls... 

{
    - hasReq:
        -> yes
    - else:
        -> no
}


-> END

=== yes ===
yay you have the thing

good job
-> END

=== no ===
go get the thing

you dont got it
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