using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private string allyIcon1;
    private string allyIcon2;
    private string allyName1;
    private string allyName2;
    public GameObject container;

    public InventoryHUD inventory;

    public void Start(){

        if(PlayerPrefs.HasKey("allyName1"))
        {
            allyIcon1 = PlayerPrefs.GetString("allyIcon1");
            allyIcon2 = PlayerPrefs.GetString("allyIcon2");
            allyName1 = PlayerPrefs.GetString("allyName1");
            allyName2 = PlayerPrefs.GetString("allyName2");
        }else{
            PlayerPrefs.SetInt("numberAlly1",0);
            PlayerPrefs.SetInt("numberAlly2",0);
            PlayerPrefs.SetString("allyIcon1","null");
            PlayerPrefs.SetString("allyIcon2","null");
            PlayerPrefs.SetString("allyName1","null");
            PlayerPrefs.SetString("allyName2","null");
            PlayerPrefs.SetString("allyRarety1","null");
            PlayerPrefs.SetString("allyRarety2","null");
            allyIcon1 = "null";
            allyIcon2 = "null";
            allyName1 = "null";
            allyName2 = "null";
        }

        if(this.gameObject.transform.name == "ring1" && allyIcon1 != "null")
        {
            this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = allyName1;
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
        }
        if(this.gameObject.transform.name == "ring2" && allyIcon2 != "null")
        {
            this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = allyName2;
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        string name = eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text;
        Item newItem = inventory.getItem(name);
        if (eventData.pointerDrag != null)
        {
            Item oldItem = new Item(0,"x","x","x","x",0);
            if(this.gameObject.transform.name == "ring1")
            {
                if(allyName1 != null)
                {
                    inventory.addItem(allyName1);
                    oldItem = inventory.getItem(allyName1);
                }
                PlayerPrefs.SetInt("numberAlly1",newItem.number);
                PlayerPrefs.SetString("allyIcon1",newItem.icon);
                PlayerPrefs.SetString("allyName1",newItem.name);
                PlayerPrefs.SetString("allyRarety1",newItem.rarety);
                allyIcon1 = newItem.icon;
                allyName1 = newItem.name;
                this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = newItem.name;
            }
            if(this.gameObject.transform.name == "ring2")
            {
                if(allyName2 != null)
                {
                    inventory.addItem(allyName2);
                    oldItem = inventory.getItem(allyName2);
                }
                PlayerPrefs.SetInt("numberAlly2",newItem.number);
                PlayerPrefs.SetString("allyIcon2",newItem.icon);
                PlayerPrefs.SetString("allyName2",newItem.name);
                PlayerPrefs.SetString("allyRarety2",newItem.rarety);
                allyIcon2 = newItem.icon;
                allyName2 = newItem.name;
                this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = newItem.name;
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            inventory.removeItem(newItem.name);
            inventory.save();

            GameObject returnToInventory = GameObject.Instantiate(container.transform.GetChild(0).gameObject);
            returnToInventory.transform.SetParent(container.transform);
            returnToInventory.transform.localScale = new Vector3(1,1,1);
            returnToInventory.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + oldItem.icon);
            returnToInventory.transform.GetChild(1).GetComponent<Text>().text = oldItem.name;
            returnToInventory.transform.GetChild(2).GetComponent<Text>().text = oldItem.rarety;
            returnToInventory.transform.GetChild(3).GetComponent<Text>().text = oldItem.number.ToString();
            returnToInventory.transform.GetChild(4).GetComponent<Text>().text = oldItem.icon;
        }
        Destroy(eventData.pointerDrag);

    }
}
