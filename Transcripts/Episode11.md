# Episode 11
### [Youtube Link](https://www.youtube.com/watch?v=FhAdkLC-mSg&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=12)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**Player Attack**
- Create CharacterCombat script under Scripts
- Add script to Player and Enemy in scene

- Edit Enemy.cs, test by hitting enemy (look at debug logs for attack)
- Edit CharacterCombat to include cooldowns, test by hitting enemy
- Comment out Interactable.cs debug log

**Enemy Attack**
- Edit EnemyController for enemy can attack

**Player Die**
- Edit PlayerStats and PlayerManager to have player die
- Lighting change on scene reload is a bug, but is editor only
  - lighting -> debug settings -> disable auto generate
  - click generate lighting
  - This requires you to generate lighting every time you change the lighting and environment
  - Not necessary, as only a bug in the editor, so keep as auto generate
  
 **Parameters for Future Animations**
 - Delay coroutine is for the attack does not happen until certain point in animation
 - Explain what is IEnumerable, yield, and Coroutines
 - Explain Action for OnAttack action
