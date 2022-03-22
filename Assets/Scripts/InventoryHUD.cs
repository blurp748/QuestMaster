using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    [SerializeField] string fileName;

    List<Item> characterInventory = new List<Item>();
    public GameObject itemHUD;

    void Start()
    {
        characterInventory = FileHandler.readFromJSON<Item>(fileName);
        foreach(Item item in characterInventory)
        {
            if (item == characterInventory[0])
            {
                itemHUD.transform.GetChild(1).GetComponent<Text>().text = item.icon;
                itemHUD.transform.GetChild(2).GetComponent<Text>().text = item.rarety;
                itemHUD.transform.GetChild(3).GetComponent<Text>().text = item.number.ToString();
                itemHUD.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + item.icon);
            }else{
                GameObject duplicate = GameObject.Instantiate(itemHUD);
                duplicate.transform.SetParent(itemHUD.transform.parent,false);
                duplicate.transform.GetChild(1).GetComponent<Text>().text = item.icon;
                duplicate.transform.GetChild(2).GetComponent<Text>().text = item.rarety;
                duplicate.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + item.icon);
            }
        }
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
