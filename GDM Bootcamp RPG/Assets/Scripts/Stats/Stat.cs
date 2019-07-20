using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// We want unity to serialize this custom class
// such that the fields within this class are
// visibile within the inspector
[System.Serializable]
public class Stat
{

    [SerializeField]
	private int baseValue;

	private List<int> modifiers = new List<int>();

    public int GetValue()
	{
		return baseValue;
	}

    public void AddModifier(int modifier)
	{
        if (modifier != 0)
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
