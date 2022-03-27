using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeButton : MonoBehaviour
{
    public Button mergeButton;
    public InventoryHUD inventory;
    public GameObject slot1;
    public GameObject slot2;
    public MergeDatabase mergeDatabase;
    public GameObject container;

    void Start()
    {
        mergeButton.onClick.AddListener(OnMerge);     
    }

    private void OnMerge()
    {
        string item1Name = slot1.transform.GetChild(1).GetComponent<Text>().text;
        string item2Name = slot2.transform.GetChild(1).GetComponent<Text>().text;

        if(item1Name != "" && item2Name != "")
        {

            string result = mergeDatabase.findItem(item1Name+item2Name);
            Debug.Log("Resultat : "+result);

            //inventory.removeItem(item1Name);
            //inventory.removeItem(item2Name);

            if(result != "")
            {
                inventory.addItem(result);
                Item resultItem = inventory.getItem(result);
                GameObject returnToInventory = GameObject.Instantiate(container.transform.GetChild(0).gameObject);
                returnToInventory.transform.SetParent(container.transform);
                returnToInventory.transform.localScale = new Vector3(1,1,1);
                returnToInventory.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>("Monsters/" + resultItem.icon);
                returnToInventory.transform.GetChild(1).GetComponent<Text>().text = resultItem.name;
                returnToInventory.transform.GetChild(2).GetComponent<Text>().text = resultItem.rarety;
                returnToInventory.transform.GetChild(3).GetComponent<Text>().text = resultItem.number.ToString();
                returnToInventory.transform.GetChild(4).GetComponent<Text>().text = resultItem.icon;
            }
            inventory.save();
        }
    }
}
