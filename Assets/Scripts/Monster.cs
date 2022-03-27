using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    public string familyName;
    public int difficulty;
    public List<string> monsterNames;
    public List<string> loots;

    public Monster(string familyName,int difficulty, List<string> monsterNames, List<string> loots)
    {
        this.familyName = familyName;
        this.difficulty = difficulty;
        this.monsterNames = monsterNames;
        this.loots = loots;
    }

    public Monster(Monster monster)
    {
        this.familyName = monster.familyName;
        this.difficulty = monster.difficulty;
        this.monsterNames = monster.monsterNames;
        this.loots = monster.loots;
    }
}
