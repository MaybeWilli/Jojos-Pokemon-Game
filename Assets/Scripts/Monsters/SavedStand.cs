using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedStand
{
    public GameObject prefab;
    public int level;
    public string name;

    public SavedStand(GameObject p, int l, string n)
    {
        prefab = p;
        level = l;
        name = n;
    }
}
