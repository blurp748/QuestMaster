using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    [SerializeField] string fileName;

    private List<Item> characterInventory = new List<Item>();
    public GameObject itemHUD;
    public ItemDatabase itemDatabase;

    void Start()
    {
        characterInventory = FileHandler.readFromJSON<Item>(fileName);
        foreach(Item item in characterInventory)
        {
            if (item == characterInventory[0])
            {
                itemHUD.transform.GetChild(1).GetComponent<Text>().text = item.name;
                itemHUD.transform.GetChild(2).GetComponent<Text>().text = item.rarety;
                itemHUD.transform.GetChild(3).GetComponent<Text>().text = item.number.ToString();
                itemHUD.transform.GetChild(4).GetComponent<Text>().text = item.icon;
                itemHUD.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + item.icon);
            }else{
                GameObject duplicate = GameObject.Instantiate(itemHUD);
                duplicate.transform.SetParent(itemHUD.transform.parent,false);
                duplicate.transform.GetChild(1).GetComponent<Text>().text = item.name;
                duplicate.transform.GetChild(2).GetComponent<Text>().text = item.rarety;
                duplicate.transform.GetChild(3).GetComponent<Text>().text = item.number.ToString();
                duplicate.transform.GetChild(4).GetComponent<Text>().text = item.icon;
                duplicate.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + item.icon);
            }
        }
    }

    public List<Item> getInventory()
    {
        return characterInventory;
    }

    public Item checkItem(int id)
    {
        return characterInventory.Find( item => item.id == id);
    }

    public Item checkItem(string name)
    {
        return characterInventory.Find( item => item.name == name);
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

    public void removeItem(string name)
    {
        Item item = checkItem(name);
        if (item != null)
        {
            characterInventory.Remove(item);
            Debug.Log("Item removed : "+item.name);
        }
    }

    public void addItem(int id)
    {
        Item item = itemDatabase.getItem(id);
        if (item != null)
        {
            characterInventory.Add(item);
            Debug.Log("Item added : "+item.name);
        }
    }

    public Item getItem(string name)
    {
        return itemDatabase.getItemByName(name);
    }

    public void addItem(string name)
    {
        Item item = itemDatabase.getItemByName(name);
        if (item != null)
        {
            characterInventory.Add(item);
            Debug.Log("Item added : "+item.name);
        }
    }

    public void save()
    {
        Debug.Log("Sauvegarde ..");
        FileHandler.saveToJSON<Item>(characterInventory,fileName);
    }
}
