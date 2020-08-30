# Episode 6
### [Youtube Link](https://www.youtube.com/watch?v=YLhj7SfaxSE&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=7)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

  **Items UI Functionality**
- canvas has InventoryUI script
- Show UpdateUI function in InventoryUI works by right-clicking on items in world (prints "UpdatingUI")
- InventorySlot script on InventorySlot objects
  - references icon child object (apply prefab)
 - InventoryUI reference to itemsParent grand-child object
 - Make sure GameManager spaces = 20
 - duplicate scriptable object "Test Item" in assets, rename them to "Helmet" and "Shield"
 - Make 1st test item in hierarchy a helmet, with name variable = "Helmet of Protection", icon becomes Placeholder01 sprite
   - other two test items become Shield items, with Placeholder02 sprite
 - InventorySlot has removeButton reference and the button itself references this script for OnRemoveButton OnClick event in Inspector
   - apply InventorySlot prefab
 
 **Using Item Functionality**
 - describe virtual keyword
 - itemButton has reference to InventorySlot script in OnClick event in Inspector with UseItem function
 - now clicking on items in inventory prints ("Using " + name of item)
 
 **Open/Close Inventory**
 - Edit -> ProjectSettings -> Input 
 - Axes size from 18 to 19
 - rename last one to Inventory, positive key = i, alt positive key = b
 - Canvas InventoryUI script has reference to Inventory child object
 - explain EventSystem briefly
 - disable Inventory object (so its disabled on default)
 
 **Organize Scripts**
 - create Items folder under Scripts, place in Item.cs, ItemPickup.cs
 - create Inventory folder under Scripts, place in InventoryUI.cs, InventorySlot.cs, Inventory.cs
 - create Prefabs folder under Assets, place in InventorySlot prefab
