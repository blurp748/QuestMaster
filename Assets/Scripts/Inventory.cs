using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] string fileName;

    List<Item> characterInventory = new List<Item>();
    public ItemDatabase itemDatabase;

    private void Start()
    {
        characterInventory = FileHandler.readFromJSON<Item>(fileName);
        string loot = PlayerPrefs.GetString("loot");
        if(loot != "")
        {
            addItemByName(loot);
            PlayerPrefs.SetString("loot","");
            save();
        }
    }

    public void addItem(int id)
    {
        Item itemAdd = itemDatabase.getItem(id);
        characterInventory.Add(itemAdd);
        Debug.Log("Added item : "+itemAdd.name);
    }

    public void addItemByName(string name)
    {
        Item itemAdd = itemDatabase.getItemByName(name);
        characterInventory.Add(itemAdd);
        Debug.Log("Added item : "+itemAdd.name);
    }

    public Item checkItem(int id)
    {
        return characterInventory.Find( item => item.id == id);
    }

    public void removeItem(int id)
    {
        Item item = checkItem(id);
        if (item != null)
        {
            characterInventory.Remove(item);
            Debug.Log("Item removed : "+item.name);
        }
    }

    public void save()
    {
        Debug.Log("Sauvegarde ..");
        FileHandler.saveToJSON<Item>(characterInventory,fileName);
    }
}
