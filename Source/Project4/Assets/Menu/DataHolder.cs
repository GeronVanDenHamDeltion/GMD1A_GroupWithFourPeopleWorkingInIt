using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataHolder
{
    public Vector3 playerlocation;
    public Vector3 playerRotation;
    public List<bool> pageAbleToSee = new List<bool>();
    public int currentScene;
}
