using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "New Item";    // Name of the item
    public Sprite icon = null;              // Item icon
    public bool isDefaultItem = false;		// Is the item default wear?


    //virtual = can override in derived classes
    //ex: Shape has virtual Area function  height * width 
    //Circle has a different area formula, so it overrides it
    public virtual void Use()
    {
        //Use the item
        //Something might happen

        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
