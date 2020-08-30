# Episode 8
### [Youtube Link](https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=9)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**New player model**
- Download new player.blend
- In file explorer, delete old player.blend and drag in new player.blend
  - this saves the Unity settings
- Download 3 default clothing sprites, put in sprites folder, set Texture Type to Sprite (2D and UI), press apply
- Set all character material smoothnesses to 0
- Under Items folder, create Meshes folder
  - NEW right click PlayerGraphics, click unpack prefab
  - from player object, drag in Hair, Helmet, Pants, Platebody, Platelegs, Shirt, and Shoes (all but body) to make prefabs
	- Delete from player object after

**New item meshes**
- Once add SkinnedMeshRenderer reference in Equipment.cs:
  - Rename "Helmet of Fire" item (in assets) to "Helmet" (and its name parameter)
  - Drag helmet mesh into that item/equipment slot reference
  - Change icon to new Helmet sprite
  - Do the same for the "Helmet of Protection" and "Shield of Destiny" to platelegs and platebody. Change equipment slot enums as well
  - Make empty gameobject named "Test pickups", reset its transform
    - Add the three test items, renaming them to "Platebody/Platelegs/Helmet pickup"
- After adding SkinnedMeshRenderer info in EquipmentManager.cs:
  - GameManager, set targetMesh to Body of player
- After adding EquipmentMeshRegion enum
  - (In assets) Helmet = none, Platebody = arms, torso, Platelegs = legs

**Default items**
  - For hair, shirt, pants, shoes -> make new Equipment
    - set name to "Default Shoes" for example, (and name parameter)
    - set EquipmentSlot, no icon, isDefaultItem = TRUE
    - set mesh, set EquipmentMeshRegions (Pants = legs, Shirt = arms, torso)
  - Go to GameManager, lock inspector, click all default items, drag into DefaultItems array, unlock inspector

**Item Scene Objects**
  - Create folder under scripts "Helper", create script inside called "ConvertToRegularMesh"
  - Add Helmet, Platebody, Platelegs assets into scene. Add the new script to them. On cogwheel symbol on the script component, click "Convent to regular mesh"
    - They should now be visible in the scene
  - Create folder under Prefabs called "Equipment Previews"
    - Drag in the three new objects from scene, selecting "Original prefab" if popup shows up, reset transforms of prefabs
    - Delete those three objects in scene
    - three test pickups set scale to 1,1,1, remove mesh filter and mesh renderer components, add new model prefabs as children
    - rotate helmet 270 deg
    - Match box colliders better
