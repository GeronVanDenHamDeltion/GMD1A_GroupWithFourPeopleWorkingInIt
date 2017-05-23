using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public enum Itemtype
    {
        Note,
        Drugs,
        Momento
    }
    public string Name;
    public Itemtype itemType;
    public int itemID;
    public Sprite sprite;
    public string description;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
