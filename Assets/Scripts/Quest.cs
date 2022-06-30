using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Quest : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] string fileName;

    private List<QuestHandler> quest;

    public void setQuest(QuestHandler quest)
    {
        this.quest = new List<QuestHandler>();
        this.quest.Add(new QuestHandler(quest));

        GameObject child_title =  this.gameObject.transform.GetChild(0).gameObject; 
        child_title.GetComponent<UnityEngine.UI.Text>().text = quest.questKind;

        GameObject child_level =  this.gameObject.transform.GetChild(2).gameObject; 
        child_level.GetComponent<UnityEngine.UI.Text>().text = "Lv" + quest.requireLvl.ToString();

        GameObject child_description =  this.gameObject.transform.GetChild(1).gameObject; 
        child_description.GetComponent<UnityEngine.UI.Text>().text = quest.description;

        GameObject child_difficulty =  this.gameObject.transform.GetChild(3).gameObject; 
        child_difficulty.GetComponent<UnityEngine.UI.Text>().text = quest.difficulty.ToString();

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        save();
        SceneManager.LoadScene(1);
    }

    private void save()
    {
        FileHandler.saveToJSON<QuestHandler>(quest,fileName);
    }
}
