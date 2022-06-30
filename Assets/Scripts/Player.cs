using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int health;
    private int reqExp;
    private int currExp;
    private int level;
    private int damage;
    private int story;

    void Start()
    {
        read_data();
    }

    public void read_data()
    {
        health = PlayerPrefs.GetInt("health");
        reqExp = PlayerPrefs.GetInt("reqExp");
        currExp = PlayerPrefs.GetInt("currExp");
        level = PlayerPrefs.GetInt("level");
        damage = PlayerPrefs.GetInt("damage");
        story = PlayerPrefs.GetInt("story");
    }

    public void setValues(int HP, int R_EXP, int C_EXP, int LVL, int DMG, int story){
        PlayerPrefs.SetInt("story",story);
        PlayerPrefs.SetInt("health",HP);
        PlayerPrefs.SetInt("level",LVL);
        PlayerPrefs.SetInt("damage",DMG);
        PlayerPrefs.SetInt("currExp",C_EXP);
        PlayerPrefs.SetInt("reqExp",R_EXP);
    }

    public int getHealth(){
        return health;
    }

    public int getReqExp(){
        return reqExp;
    }

    public int getCurrExp(){
        return currExp;
    }

    public int getLevel(){
        return level;
    }

    public int getDamage(){
        return damage;
    }
}
