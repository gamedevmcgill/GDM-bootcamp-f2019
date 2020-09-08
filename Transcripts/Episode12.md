# Episode 12
### [Youtube Link](https://www.youtube.com/watch?v=yhPRkihs-Yg&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=13)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**Player Combat**
- Add CharacterCombat script component to player and enemy parents
- Edit Enemy interact script
- Test by hitting enemy
- Edit CharacterCombat again for cooldown code
- Test cooldown, click != hit every time (kinda hard to see when testing)

**Player Die, Enemy Hitting**
- Comment out interactable debug log
- Edit EnemyController for enemy attacking
- Test enemy hits player
- Edit PlayerStats & PlayerManager -> Die override, restarts game

**Lighting Aside**
- //Lighting change on scene change: EDITOR only bug
- //fix by: lighting -> debug settings -> disable auto generate
- //then click generate lighting whenever change envir or lighting
- //its annoying to have to keep generating, so we will not do this

**Explanation Aside**
Explain enumerable, yield, actions
