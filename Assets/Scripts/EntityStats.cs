using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStats : MonoBehaviour
{
    private int health;
    private int damage;
    private int level;

    public HealthBar healthBar;

    public void setStats(int health, int damage, int level)
    {
        this.health = health;
        this.damage = damage;
        this.level = level;
        this.healthBar.setMaxHealth(health);
    }

    public void takeDamage(int DMG){

        if (this.health > 0) {
            this.health -= DMG;
            healthBar.setHealth(this.health);
        }  
        else{
            Debug.Log ("You're dead!");
        }
    }

    public bool isAlive()
    {
        return health>0;
    }

    public int getHealth()
    {
        return health;
    }

    public int getDamage()
    {
        return damage;
    }
}
