using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    #region Fields & Properties

    public string Name { get; private set; }
    public string Description { get; private set; }
    public ItemType Type { get; private set; }

    public int Attack { get; private set; }
    public int Defense { get; private set; }

    #endregion

    #region Constructor

    public Item(string name, string description, ItemType type, int attack, int defense)
    {
        Name = name;
        Description = description;
        Type = type;
        Attack = attack;
        Defense = defense;
    }

    #endregion
}