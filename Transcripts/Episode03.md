# Episode 3
### [Youtube Link](https://www.youtube.com/watch?v=S2mK6KFdv0I&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=4)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

//Just give them the new Player.blend file

**PLAYER.BLEND PRE-SETUP**

**Player Model Setup**

- Create "Characters" folder
- Drag in Player.blend
- Click Rig panel of blend file
- Change Generic -> Humanoid Animation type and hit APPLY
- Click configuration right above apply
- Click pose -> sample bind pose, then enforce T-pose
- //Player lies down in sample bind pose because coordinate system is different in blender
- Click Apply, then Done

**Animation Setup**

- Click Animation panel of blend file
- Enable loop time on all Animation Clips
- Motion dropdown -> Root Motion Mode -> Root Transform
- Press apply

**PLAYER.BLEND PRE-SETUP END**

**Player Animator**

- Delete Player child game object, replace with Player.blend, rename to Player Graphic
- Create AnimatorController and name it Player Animator
- Attach Player Animator to Controller reference spot of Player Graphic's Animator component
- Disable "Apply Root Motion", motion controlled by scripts in this project

**Player Animator Blend Tree**

//Do we want this predone?

- Double click on Player Animator
- Create new blend tree naming it "Locomotion" by right clicking in view
- Double click on new blend tree image to open it
- Parameters -> Motion -> + sign -> Add three Motion fields
- Place in fields Idle, Walk, Run
- On the left in Parameters column, rename Blend parameter to speedPercent


Create new script called "CharacterAnimator" and add to parent Player GO

After done with script, play game, click to show running smooths to a walk

