# Episode 2
### [Youtube Link](https://www.youtube.com/watch?v=S2mK6KFdv0I&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=3)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)


**interaction setup**

Create new script called Interactable
explain Gizmos for debugging
Interactable Example Sphere GameObject
  - create, put on bridge
  - add interactable script
  - show OnDrawGizmo radius by changing public radius
  
//was previously at end of video

Rename sphere to interactable

**focus and follow**

Player's focus
  - Show focus of player by playing and watching the PlayerController's focus variable change
    - left mouse button = defocus
    - right mouse button = focus clicked interactable (sphere)
    
Follow target
  - show that the player follows the target by moving the focused sphere while in play mode
  
Stopping radius
  - click on sphere again to focus, showing stopping distance is radius
  
Face Target
  - show that when moving the sphere, the player does not face the target
  - explain that Quaternion holds rotation methods, pray
  - draw lookat "direction" vector on board
  - mention resource for slerp for smoother rotation
  - show in play mode the player faces target even when within stopping radius
  
**interact**

Interacted
  - Debug.Log("INTERACT") show in console
  - explain that to prevent constantly going through code in Update, set hasInteracted bool
  
 Explain Virtual methods
 
 Demonstrate interactionTransform vs default transform by adding a transform to the sphere and setting that as interactionTransform
    - example given : chest has transform in front only for interacting
