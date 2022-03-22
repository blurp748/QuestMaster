using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneBuilder : MonoBehaviour
{
    public GameObject itemQuest;
    public MonsterDatabase monsterDatabase;

    private int playerStory;
    private int playerLevel;

    void Start()
    {

        if (PlayerPrefs.HasKey("story")){

            playerStory = PlayerPrefs.GetInt("story");
            playerLevel = PlayerPrefs.GetInt("level");

        }else{

            PlayerPrefs.SetInt("story",0);
            PlayerPrefs.SetInt("health",100);
            PlayerPrefs.SetInt("level",1);
            PlayerPrefs.SetInt("damage",5);
            PlayerPrefs.SetInt("currExp",0);
            PlayerPrefs.SetInt("reqExp",(int)(Math.Exp(playerLevel/5)+Math.Pow(playerLevel,3)));
            playerStory = 0;
            playerLevel = 1;

        }

        for(int i =0;i<playerStory;i++)
        {
                Monster quest = monsterDatabase.getItem(i);
                int rdm = UnityEngine.Random.Range(1,6);
                GameObject duplicateQuest = GameObject.Instantiate(itemQuest);
                duplicateQuest.transform.SetParent(itemQuest.transform.parent,false);
                duplicateQuest.GetComponent<Quest>().setQuest(new QuestHandler(quest.familyName,UnityEngine.Random.Range(1,playerLevel+3),"Nombre d'ennemi :"+rdm.ToString(),quest.difficulty,rdm,quest.monsterNames,quest.loots));
        }

        switch(playerStory)
        {
            case 0:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",1,"Quete principale 1",1,1, new List<string>(){"Arcane Crystal"},new List<string>()));
                break;
            case 1:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",5,"Quete principale 2",1,1, new List<string>(){"Arcane Crystal Magic Circle"},new List<string>()));
                break;
            case 2:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",20,"Quete principale 3",2,1, new List<string>(){"Boss Flynn The Original Slime"},new List<string>()));
                break;
            case 3:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",30,"Quete principale 3",2,1, new List<string>(){"Toxic Carnivorous Plant C"},new List<string>()));
                break;
            case 4:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",35,"Quete principale 3",2,1, new List<string>(){"Skeleton Dragon"},new List<string>()));
                break;
            case 5:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",40,"Quete principale 3",2,1, new List<string>(){"Sea Beach Turtle"},new List<string>()));
                break;
            case 6:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",50,"Quete principale 3",2,1, new List<string>(){"Boss Orc Chief Grunt"},new List<string>()));
                break;
            case 7:
                itemQuest.GetComponent<Quest>().setQuest(new QuestHandler("Story",60,"Quete principale 3",2,1, new List<string>(){"Eldritch God ShacadYoggoth"},new List<string>()));
                break;
            default:   
                Destroy(itemQuest);
                break;
        }
    }
}
