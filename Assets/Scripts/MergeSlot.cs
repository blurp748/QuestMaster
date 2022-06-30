using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MergeSlot : MonoBehaviour, IDropHandler, IPointerDownHandler
{

    public InventoryHUD inventory;
    public GameObject container;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        if (eventData.pointerDrag != null)
        {
            GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
            string name = eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text;
            this.gameObject.transform.GetChild(1).GetComponent<Text>().text = name;
        }
        Destroy(eventData.pointerDrag);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.gameObject.transform.GetChild(1).GetComponent<Text>().text != "")
        {
            Item returnItem = inventory.getItem(this.gameObject.transform.GetChild(1).GetComponent<Text>().text);

            GameObject returnToInventory = GameObject.Instantiate(container.transform.GetChild(0).gameObject);
            returnToInventory.transform.SetParent(container.transform);
            returnToInventory.transform.localScale = new Vector3(1,1,1);
            returnToInventory.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + returnItem.icon);
            returnToInventory.transform.GetChild(1).GetComponent<Text>().text = returnItem.name;
            returnToInventory.transform.GetChild(2).GetComponent<Text>().text = returnItem.rarety;
            returnToInventory.transform.GetChild(3).GetComponent<Text>().text = returnItem.number.ToString();
            returnToInventory.transform.GetChild(4).GetComponent<Text>().text = returnItem.icon;

            this.gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
            GetComponent<Image>().sprite = Resources.Load<Sprite>("GUI_Parts/Gui_parts/Mini_frame0");

        }
    }
}
