# Episode 13
### [Youtube Link](https://www.youtube.com/watch?v=aOmqkTdqQXo&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=14)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**Health UI Prefab Setup**
- healthbar into Sprite folder, texture type = Sprite (2D and UI), press apply
- unlike the normal UI, for personal preference we want the health UI to go behind objects in the scene
  - to do so: create new canvas, set render mode to world space
- reset canvas transform, create image child with sprite = health bar
  - set image's x and z position to the same as the parent player object
  - scale the image to about 0.004, click "set native size" for aspect ratio correction, move down to above players head
  - set image color to red, dup it and set the second one as a child of it with a green color
  - green image -> set image type = Filled, Fill method = Horizontally, Fill Origin = Left, show by moving fill amount slider, then leave value at 1
  - rename Health UI and child Background, then drag into Prefabs folder and delete the object from the world
- create "HealthUI" script under Scripts


**Health UI Script**
- go to HealthUI script's inspector, place the healthUI prefab into the uiPrefab variable to make it the default prefab
  - add the script to the player
- add empty child GO to player called "Health UI Target", set y to about 2, add this as the player's "HealthUI" component target variable
  - do the same for the enemy, but y = 2.8
- test the health bar shows up
- add damage info to the HealthUI script and corresponding event on the CharacterStats script
- test health bar shows up only on combat, decreases, and goes away after no damage for a while

**Enemy Setup**
- add Skeleton.blend
- under animation tab, combat_idle, idle, and walk check off loop time, press apply
- since the animations happen to be the same as player, we will be using the same animator as the player
  - create AnimationOverrideController called SkeletonOverride, set Controller to PlayerAnimator, replace clips to skeleton ones from the blend file
- adapt CharacterAnimator script to allow override controller in inspector
- add CharacterAnimator component to Enemy, set override controller to the skeleton one
- set 2 default Attack Anims, the Attack_01 and Attack_02 skeleton anims
- set Replaceable Attack Anim to the PLAYER'S Punch anim
- under CharacterCombat component of skeleton, set Attack Speed to 0.7
- delete Enemy Model child object, drag in Skeleton to replace
  - scale the Skeleton child to about 1.4 and his Animator component set Animator as the Player Animator
- test

**Enemy Anim based on Anim Events**
- //this script is because whichever GO has animator will receive data, but our anim scripts are on the parent of the Model with the animator
- Create script "CharacterAnimationEventReceiver"
...
- Add this script to the player and enemy, setting up their corresponding Combat variables in the component
- Go to player.blend, under Animation tab click the punch anim
  - UNDER Events, do not move the slider next to the + sign, but the slider in the animation viewing tab
  - slide until get to moment of impact to target, soon before 0.40, now click + under Events again, the blue slider should move to the white slider spot
  - function = AttackHitEvent
   - do the same for the other two sword attacks, click apply
   - do the same for the enemy skeleton, click apply
test it all out
