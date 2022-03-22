using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private int numberAlly1;
    private int numberAlly2;
    private string allyIcon1;
    private string allyIcon2;
    private string allyName1;
    private string allyName2;

    public void Start(){

        if(PlayerPrefs.HasKey("numberAlly1"))
        {
            numberAlly1 = PlayerPrefs.GetInt("numberAlly1");
            numberAlly2 = PlayerPrefs.GetInt("numberAlly2");
            allyIcon1 = PlayerPrefs.GetString("allyIcon1");
            allyIcon2 = PlayerPrefs.GetString("allyIcon2");
            allyName1 = PlayerPrefs.GetString("allyName1");
            allyName2 = PlayerPrefs.GetString("allyName2");
        }else{
            PlayerPrefs.SetInt("numberAlly1",1);
            PlayerPrefs.SetInt("numberAlly2",1);
            PlayerPrefs.SetString("allyIcon1","null");
            PlayerPrefs.SetString("allyIcon2","null");
            PlayerPrefs.SetString("allyName1","null");
            PlayerPrefs.SetString("allyName2","null");

            numberAlly1 = 1;
            numberAlly2 = 1;
            allyIcon1 = "null";
            allyIcon2 = "null";
            allyName1 = "null";
            allyName2 = "null";
        }

        if(this.gameObject.transform.name == "ring1" && allyIcon1 != "null")
        {
            this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = allyIcon1;
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
        }
        if(this.gameObject.transform.name == "ring2" && allyIcon2 != "null")
        {
            this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = allyIcon2;
            this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop");
        if (eventData.pointerDrag != null)
        {
            if(this.gameObject.transform.name == "ring1")
            {
                int set;
                int.TryParse(eventData.pointerDrag.transform.GetChild(3).GetComponent<Text>().text,out set);
                PlayerPrefs.SetInt("numberAlly1",set);
                PlayerPrefs.SetString("allyIcon1",eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text);
                PlayerPrefs.SetString("allyName1",eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text);
                this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text;
            }
            if(this.gameObject.transform.name == "ring2")
            {
                int set;
                int.TryParse(eventData.pointerDrag.transform.GetChild(3).GetComponent<Text>().text,out set);
                PlayerPrefs.SetInt("numberAlly2",set);
                PlayerPrefs.SetString("allyIcon2",eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text);
                PlayerPrefs.SetString("allyName2",eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text);
                this.gameObject.transform.parent.GetChild(0).GetComponent<Text>().text = eventData.pointerDrag.transform.GetChild(1).GetComponent<Text>().text;
            }
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
        }
        Destroy(eventData.pointerDrag);

    }
}
