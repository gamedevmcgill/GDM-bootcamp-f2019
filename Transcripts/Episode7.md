# Episode 7
### [Youtube Link](https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=8)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**Equipment Item examples**
- Create script Equipment under Scripts -> Items
- Create an Equipment object in contents, name Helmet of Fire  (also name it in inspect)
  - image = Placeholder01 sprite
- Remove Item objects in contents
- duplicate the Equipment object, name = Helmet of Protection (also name it in inspect)
  - image = Placeholder02 sprite
- Delete Test Item 2 in hierarchy
- Rename Test Item in hierarchy to Helmet of Fire, drag in corresponding Equipment object
  - Do same for Test Item 1 with Helmet of Protection
  
**Equipment stats**
- Explain enums
- Go into Eqipment asset objects
  - Helmet of Protection armor = 3, damage = 0
  - Helmet of Fire armor = 2, damage = 1

**Equipment Management**
- Create script EquipmentManager on GameManager object, put in Scripts folder
- Test with Debug Mode
  - top of Inspector, (right of lock icon, looks like equal sign), click Debug Mode
  - This shows private variables and other stuff, will show private currentEquipment array
  - Show equip helmet once item is right clicked and then clicked on in inventory
- Get out of Debug Mode
- Duplicate one of the items in hierarchy, rename "Sword of Destiny"
  - Create corresponding Equipment in contents, rename it (and rename the name variable in inspector), EquipmentSlot = weapon, armor = 0, damage = 3
  - Reference this Equipment scriptable obj into actual object in hierarchy
  - Test again

**Remove from inventory on Equip and Swap on replacing equiped item**
- Not much here

**Unequip**
- Press U to unequip all items after equiping a the sword and a helmet
  - Can see currentEquipment array in EquipmentManager under GameManager only in Debug Mode
  
**OnEquipmentChange**
- This delegate is used in future for other scripts can change the equipment visually on the player



