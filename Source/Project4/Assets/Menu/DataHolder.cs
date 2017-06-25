﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DataHolder
{
    public Vector3 playerlocation;
    public List<bool> pageAbleToSee = new List<bool>();
    public int currentScene;
    public int progress;
}
