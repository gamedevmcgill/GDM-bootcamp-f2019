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

    public int GetValue()
	{
		return baseValue;
	}

}
