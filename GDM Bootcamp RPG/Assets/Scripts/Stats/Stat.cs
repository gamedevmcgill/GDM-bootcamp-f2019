using System.Collections.Generic;
using UnityEngine;

//fields will show up in inspector
[System.Serializable]
public class Stat //example = armor stat
{
    [SerializeField] private int baseValue;

    private List<int> modifiers = new List<int>();

    //sometimes written as a variable: public int BaseValue => baseValue;
    public int GetValue()
    {
        int finalValue = baseValue;

        /*
        can also be written as:
        1. modifiers.ForEach(x => finalValue += x);
        
        2. foreach(int modifier in modifiers)
        {
            finalValue += modifier;
        }
        */
        for (int i = 0; i < modifiers.Count; i++)
        {
            finalValue += modifiers[i];
        }

        return finalValue;
    }

    public void AddModifier(int modifier)
    {
        if(modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}