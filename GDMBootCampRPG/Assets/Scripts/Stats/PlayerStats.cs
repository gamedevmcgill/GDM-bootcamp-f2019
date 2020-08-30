public class PlayerStats : CharacterStats
{
    private void Start()
    {
        EquipmentManager.instance.onEquipmentChange += OnEquipmentChange;
    }

    //TODO: called twice since Equip calls UnEqip, both of which invoke the event
    private void OnEquipmentChange(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        //Kill the player
        PlayerManager.instance.KillPlayer();
    }

    //you should always unsubscribe from an event once done using it
    private void OnDestroy()
    {
        EquipmentManager.instance.onEquipmentChange -= OnEquipmentChange;
    }
}