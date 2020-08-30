# Episode 9
### [Youtube Link](https://www.youtube.com/watch?v=e8GmfoaOB4Y&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=10)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**Reorganize Items folder**
- Under Assets->Items, create folder "Objects" and sub-folders "Defaults" and "Armor"
- Drag in corresponding scriptable objects and skinned mesh prefabs into each
- Make sure scriptable objects of default items have armor and damage modifiers set to 0

**Character (Base) Stats**
- Create sub folder under Scripts called "Stats"
- Create "Stat" and "CharacterStats" scripts in the folder
- "CharacterStats" just has baseValue and GetValue() { return baseValue } for now
- Put a CharacterStats component on the player
- Test it with Update() { if(Input.GetKeyDown(Keycode.T)) { TakeDamage(10); } }

**Player Stats**
- This is to update the base values with the equipment armor and damage modifiers
- Remove the CharacterStats component on the player
- Replace the component with a new script called "PlayerStats"
- Add all the List<int> modifiers code to the Stat class
- Test with Debug mode on (top right of inspector) to see the modifier list in the player object 
