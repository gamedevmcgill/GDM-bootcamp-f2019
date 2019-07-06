# Episode 5
### [Youtube Link](https://www.youtube.com/watch?v=w6_fetj9PIw&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=6)
### [Notion](https://www.notion.so/gamedevmcgill/Dissection-of-Brackey-s-RPG-25c5b38888d840a5b5da528644c5a9ea#7c5b0616c1d942789e4f71fc1fbb1712)

**Inventory Sprites Setup**
- download and drop into Unity a panel, slot, close button, and two placeholder images with their Sprites folder
- change TextureType on all of them to Sprite (2D and UI) and click apply
- max size = 32 pixels for placeholder images

**Inventory UI**
- create UI -> panel, anchor bottom right, remove Image component, scale down about 1/2, rename Inventory, move to bottom right corner
- go to 2D mode in scene view
- show game view at the same time as scene view
- create child panel, sprite = panel, alpha = 255

**Non distorting sprite borders**
- //This creates "crisp borders" as the edges are not distorted with change in size
- double click on panel asset, go to sprite editor and change borders to 20, apply
- click on child panel in hierarchy, change ImageType to sliced

**InventorySlot**
- create child panel under the child panel, rename to InventorySlot, image = slot image, alpha = 255, width & height = 60, drag to top left, anchor to top left
- same as above: change borders to 25
- double click on slot asset, pixels per unity = 200
- create child image, sprite = placeholder01, width & height = 32, name = Icon
- add button, navigation = none (see for more on button navigation: https://www.youtube.com/watch?v=0r-A62VOZD0)
- create empty gameobject, width & height = 60, parent it to InventorySlot, rename InventorySlot to ItemButton, rename empty gameobject to InventorySlot
- under the new InventorySlot, create gameobject with image and button, image = closebutton, button navigation = none, width & height = 22, x & y = 21, rename to removebutton

-make InventorySlot a prefab by dragging into Assets, duplicate it until 20 in scene, GameManager space parameter = 20
-rename Panel to ItemsParent, add gridLayoutGroup, CellSize = 60 by 60, spacing 6 by 6, padding = 15 all but top = 27
- scale InventorySlot to fit the ItemsParent nicely

**Inventory Title**
- create Image object under Inventory (alongside ItemsParent), shrink down (width & height ~ 100 by 340), image = panel sprite, rename to Title
- create text object under Title, center align it, text = Inventory, bold font, dark brown color

**Scale Canvas**
- go to canvas -> UI Scaling Mode = Scale With Screen Size, scrollbar = to right (scale by height, not width)
- change placeholder sprites maxSize to 64 from 32, press apply

**Clear Slots By Default**
- Icon source image = none
- disable its image component as well
- RemoveButton interactable = false, disable color alpha = 0 \
- **Important** Apply button at top to apply to prefab no longer exists. Go to overrides (in same spot), click Apply All **Important**
