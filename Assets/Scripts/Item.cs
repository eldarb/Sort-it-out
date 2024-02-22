using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
public class Item : ScriptableObject
{
    public ItemTypes type;
    public GameObject model;
}

public enum ItemTypes{
    metal = 1,
    glass = 2,
    plastic = 3,
    recycling = 4
}