# MidtermGameEngine

Ryan Yee
100785620

In implementing the observer design pattern from the second question, I decided that it would be best to edit a version of
the player character, and have them move and shoot with the player when picking up the gem power up.

First, the gem has a script that checks if the gem has been shot by a bullet, if it has been, the tag of the gem object changes to
"green". If it is picked up again, it will be destroyed. Unfortuntely, I was unable to change the material to green,
but that was the intention if I was able to implement it.

A new script was added called "Summon", attached to the player. This script checks if a object colliding with the player
has the tag "green", and if so, sets a boolean which checks if the power up has been obtained to true.
From this, Two rigidbodies are created, similarly to how the bullet is created, but instead of adding projectiles,
the clones are added, each with the player controller scripts, allowing for movement and shooting.

The issues I encountered were that the jump and movement were not exactly synced up, as jumping causes weird outcomes of anti-gravity.; however, basic spawning and functionality
was added. I would try to fix this by attempting to constrain the movement of the player clones to line up with the actual player;
additionally, I would have made it so the clones follow behind the player instead of side by side.

These additions were made to somewhat try and emulate the described gem powerup mechanics (shooting it to change
the power up), as well as the clones shooting and moving with the player.
