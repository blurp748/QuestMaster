using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class QuestHandler
{
    public string questKind; // type de quête
    public int requireLvl; // niveau conseillé
    public string description;
    public int difficulty;
    public int numberEnemy;
    public List<string> sprites;
    public List<string> loots;

    public QuestHandler(string questKind,int requireLvl, string description, int difficulty, int numberEnemy, List<string> sprites,List<string> loots)
    {
        this.questKind = questKind;
        this.requireLvl = requireLvl;
        this.description = description;
        this.difficulty = difficulty;
        this.numberEnemy = numberEnemy;
        this.sprites = sprites;
        this.loots = loots;
    }

    public QuestHandler(QuestHandler quest)
    {
        this.questKind = quest.questKind;
        this.requireLvl = quest.requireLvl;
        this.description = quest.description;
        this.difficulty = quest.difficulty;
        this.numberEnemy = quest.numberEnemy;
        this.sprites = quest.sprites;
        this.loots = quest.loots;
    }
}
