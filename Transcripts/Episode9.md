# Episode 9

### [Youtube Link](hhttps://www.youtube.com/watch?v=e8GmfoaOB4Y&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=10)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#98497535f625446ea247f6ed7a5aed1d)

**Using the scriptable objects modifiers**

- Currently, the items we are wearing have no effect on gameplay (I.E armour doesn't give us any buffs yet). 

Start by resetting all damage and armour modifier on default scriptable objects.
1. Select all default scriptable objects within Assets > Items
2. Reset the armour and damage modifiers to 0

**Stats scripts**

1. Create a new folder within Scripts called "Stats"
2. Create two new scripts "CharacterStats" and "Stat" in the Scripts > Stats folder.
    - CharacterStats: Responsible for keeping track of all stats on all characters in our game. Will be able to be extended from to add more specific traits.
    - Stat: representing a single stat (like armour or damage).

~~~ Stat code changes ~~~

- Add the CharacterStats to the Player GameObject
- At this point, Brackey has added a test: whenever the user presses key, the character will take 10 points of damage.


## PlayerStats

- Our armor and damage modifiers are still unaffected by the equipment our player has equipped.
- To change that, we create a new script: `PlayerStats` that derives from `CharacterStats`

1. Remove the `CharacterStats` component from the player game object.
2. Create a new script `PlayerStats` that derives from `CharacterStats`.
3. Add this new script as a component of `Player`

