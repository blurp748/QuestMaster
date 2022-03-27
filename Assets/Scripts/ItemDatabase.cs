using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> items = new List<Item>();

    public void Awake()
    {
        BuildDatabase();
    }

    public Item getItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item getItemByName(string name)
    {
        return items.Find(item => item.name == name);
    }

    void BuildDatabase()
    {
        // Id - Rareté - Name - Icon - Description - Nombre d'ennemis
        items = new List<Item>(){
            //Slime
            new Item(0,"F","Bague du Slime","Slimei","Invoque un slime",1),
            new Item(1,"F","Bague du Slime de vent","Slime Windi","Invoque un slime de vent",1),
            new Item(2,"F","Bague du Slime du tonnerre","Slime Thunderi","Invoque un slime de tonnerre",1),
            new Item(3,"F","Bague du Slime de feu","Slime Firei","Invoque un slime de feu",1),
            new Item(4,"F","Bague du Slime sacré","Slime Holyi","Invoque un slime sacré",1),
            new Item(5,"F","Bague du Slime de terre","Slime Earthi","Invoque un slime de terre",1),
            new Item(6,"F","Bague du Slime sombre","Slime Darki","Invoque un slime sombre",1),
            new Item(7,"E","Bague du double Slime","Slimei","Invoque deux slime",2)
        };
    }
}
