using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Item
{
    public int id;
    public string rarety;
    public string name;
    public string icon;
    public string description;
    public int number;

    public Item(int id, string rarety, string name, string icon, string description, int number)
    {
        this.id = id;
        this.rarety = rarety;
        this.name = name;
        this.icon = icon;
        this.description = description;
        this.number = number;
    }

    public Item(Item item)
    {
        this.id = item.id;
        this.rarety = item.rarety;
        this.name = item.name;
        this.icon = item.icon;
        this.description = item.description;
        this.number = item.number; 
    }

}
