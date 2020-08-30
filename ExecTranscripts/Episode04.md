# Episode 4
### [Youtube Link](https://www.youtube.com/watch?v=S2mK6KFdv0I&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**item setup**

- Create 3D cube "Test Item", scaled to 0.5, move to near the player
- Create material "ItemMat" (not in a folder), albedo color = yellow
- Create script "ItemPickup", put this and mat on cube

**item pickup script**

- Review inheritance for Interactable
- In Interactable script, force set interactabletransform reference to the GO's default transform to not get null errors
- Clicking item in play mode shows Debug saying it was picked up

**Item scriptable object**

- explain scriptable objects
- On replace "Monobehavior" with "ScriptableObject", explain what Monobehavior is 
  - (ex It allows scripts to be attached to GOs in scene and use of many Unity fields like transform, gameobject, etc)
- explain "new" keyword in front of name variable
  - it override's the normal name of an object
- explain the variable defaultItem better
  - what the player has on from start and will have on whenever he removes armor (ex plain shirt and pants)
  - they are not in the inventory to not hold up space
- Create -> Inventory -> Item (new asset menu), rename "Test Item", name variable = "Helmet of Protection", isDefaultItem = false
- Create "Item" folder and put "Test Item" (the scriptable object, not the yellow cube) into it

**Inventory script**

- Create the script
- Put on empty GO called "GameManager"
- Explain using singleton as "FindObjectOfType" and "GetComponent" is slow and if theres more than one instance, it could grab the wrong one
- Explain singleton = global access & single use
- Play, show in GameManager that inventory has 1 item once "Test Item" cube is clicked on
- Later, play and show in GameManager that item isn't picked up if inventory is full
- Explain delegates
  - Talking to other classes without knowing which classes are listening to it
  - ex: buttons know they are being pressed, invokes "Im being pressed", then scripts that are listening can do what they want with that info (ie play button starts game)



  
