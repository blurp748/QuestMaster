using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest : MonoBehaviour
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

    void OnMouseDown()
    {
        /*PlayerPrefs.SetInt("numberEnemy",quest.numberEnemy);
        PlayerPrefs.SetInt("requireLvl",quest.requireLvl);
        PlayerPrefs.SetInt("difficulty",quest.difficulty);
        PlayerPrefs.SetString("questKind",quest.questKind);
        for(int i = 0 ; i< quest.numberEnemy; i++)
        {
            int rdm = UnityEngine.Random.Range(0,quest.sprites.Count);
            PlayerPrefs.SetString("enemySprite"+(i+1).ToString(),quest.sprites[rdm]);
        }*/
        save();
        SceneManager.LoadScene(1);
    }

    private void save()
    {
        FileHandler.saveToJSON<QuestHandler>(quest,fileName);
    }
}
