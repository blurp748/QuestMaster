using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] string fileName;

    public GameObject player;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    public GameObject ally1;
    public GameObject ally2;
    public GameObject ally3;
    public GameObject ally4;

    public GameObject endWindow;

    private List<QuestHandler> listQuest;
    private QuestHandler quest;

    private int playerHealth;
    private int playerDamage;
    private int playerLevel;
    private int playerReqExp;
    private int playerCurrExp;
    private string questKind;
    private int requireLvl;
    private int numberEnemy;
    private int difficulty;
    private int actual_story;
    private int numberAlly1;
    private int numberAlly2;
    private string allyName1;
    private string allyName2;
    private string allyIcon1;
    private string allyIcon2;
    private int numberAlly;

    private EntityStats playerStats;
    private EntityStats enemy1Stats;
    private EntityStats enemy2Stats;
    private EntityStats enemy3Stats;
    private EntityStats enemy4Stats;
    private EntityStats enemy5Stats;
    private EntityStats ally1Stats;
    private EntityStats ally2Stats;
    private EntityStats ally3Stats;
    private EntityStats ally4Stats;

    EntityStats tmp;
    EntityStats enemyA;

    private Transform pos;
    private Transform enemyPos;
    private Transform allyPos;
    Vector3 lastPlayerPos;
    Vector3 lastEnemyPos;
    Vector3 lastAllyPos;
    private int frame;
    private bool playerAttacking;
    private bool enemyAttacking;
    private bool allyAttacking;


    void Start()
    {
        listQuest = FileHandler.readFromJSON<QuestHandler>(fileName);
        quest = listQuest[0];
        
        frame = 0;

        numberAlly1 = PlayerPrefs.GetInt("numberAlly1");
        numberAlly2 = PlayerPrefs.GetInt("numberAlly2");
        allyIcon1 = PlayerPrefs.GetString("allyIcon1");
        allyIcon2 = PlayerPrefs.GetString("allyIcon2");
        allyName1 = PlayerPrefs.GetString("allyName1");
        allyName2 = PlayerPrefs.GetString("allyName2");
        numberAlly = numberAlly1 + numberAlly2;
        Debug.Log(numberAlly);  
        playerHealth = PlayerPrefs.GetInt("health");
        playerDamage = PlayerPrefs.GetInt("damage");
        playerLevel = PlayerPrefs.GetInt("level");
        playerReqExp = PlayerPrefs.GetInt("reqExp");
        playerCurrExp = PlayerPrefs.GetInt("currExp");
        questKind = quest.questKind;
        requireLvl = quest.requireLvl;
        numberEnemy = quest.numberEnemy;
        difficulty = quest.difficulty; 
        actual_story = PlayerPrefs.GetInt("story");

        if(numberAlly == 4)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
            ally2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
            ally3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
            ally4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
        }else if (numberAlly1 == 1 && numberAlly2 == 1)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
            ally2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);  
        }else if (numberAlly1 == 2 && numberAlly2 == 1)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
            ally3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
            ally2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
        }else if (numberAlly1 == 1 && numberAlly2 == 2)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
            ally3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
            ally2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
        }else if (numberAlly1 == 0 && numberAlly2 == 1)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
        }else if (numberAlly1 == 1 && numberAlly2 == 0)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
        }else if (numberAlly1 == 2 && numberAlly2 == 0)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
            ally2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon1);
        }else if (numberAlly1 == 0 && numberAlly2 == 2)
        {
            ally1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
            ally2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + allyIcon2);
        }

        int rdm = UnityEngine.Random.Range(0,quest.sprites.Count);
        enemy1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + quest.sprites[rdm]);
        rdm = UnityEngine.Random.Range(0,quest.sprites.Count);
        enemy2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + quest.sprites[rdm]);
        rdm = UnityEngine.Random.Range(0,quest.sprites.Count);
        enemy3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + quest.sprites[rdm]);
        rdm = UnityEngine.Random.Range(0,quest.sprites.Count);
        enemy4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + quest.sprites[rdm]);
        rdm = UnityEngine.Random.Range(0,quest.sprites.Count);
        enemy5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Monsters/" + quest.sprites[rdm]);
        playerStats = player.GetComponent<EntityStats>();
        enemy1Stats = enemy1.GetComponent<EntityStats>();
        enemy2Stats = enemy2.GetComponent<EntityStats>();
        enemy3Stats = enemy3.GetComponent<EntityStats>();
        enemy4Stats = enemy4.GetComponent<EntityStats>();
        enemy5Stats = enemy5.GetComponent<EntityStats>();
        ally1Stats = ally1.GetComponent<EntityStats>();
        ally2Stats = ally2.GetComponent<EntityStats>();
        ally3Stats = ally3.GetComponent<EntityStats>();
        ally4Stats = ally4.GetComponent<EntityStats>();

        playerStats.setStats(playerHealth,playerDamage,playerLevel);
        setActualHealth(player);

        List<EntityStats> allyList = new List<EntityStats>();
        int allyDamage = (int)(Math.Pow(playerLevel,3)*0.2);
        int allyHealth = (int)Math.Pow(playerLevel,3);

        if(numberAlly != 0)
        {
            switch(numberAlly)
            {
                case 1:
                    ally1Stats.setStats(allyHealth,allyDamage,playerLevel);
                    setActualHealth(ally1Stats.gameObject);
                    allyList.Add(ally1Stats);
                    ally1.SetActive(true);
                    break;
                case 2:
                    ally1Stats.setStats(allyHealth,allyDamage,playerLevel);
                    ally2Stats.setStats(allyHealth,allyDamage,playerLevel);
                    setActualHealth(ally1Stats.gameObject);
                    setActualHealth(ally2Stats.gameObject);
                    allyList.Add(ally1Stats);
                    allyList.Add(ally2Stats);
                    ally1.SetActive(true);
                    ally2.SetActive(true);
                    break;
                case 3:
                    ally1Stats.setStats(allyHealth,allyDamage,playerLevel);
                    ally2Stats.setStats(allyHealth,allyDamage,playerLevel);
                    ally3Stats.setStats(allyHealth,allyDamage,playerLevel);
                    setActualHealth(ally1Stats.gameObject);
                    setActualHealth(ally2Stats.gameObject);
                    setActualHealth(ally3Stats.gameObject);
                    allyList.Add(ally1Stats);
                    allyList.Add(ally2Stats);
                    allyList.Add(ally3Stats);
                    ally1.SetActive(true);
                    ally2.SetActive(true);
                    ally3.SetActive(true);
                    break;
                case 4:
                    ally1Stats.setStats(allyHealth,allyDamage,playerLevel);
                    ally2Stats.setStats(allyHealth,allyDamage,playerLevel);
                    ally3Stats.setStats(allyHealth,allyDamage,playerLevel);
                    ally4Stats.setStats(allyHealth,allyDamage,playerLevel);
                    setActualHealth(ally1Stats.gameObject);
                    setActualHealth(ally2Stats.gameObject);
                    setActualHealth(ally3Stats.gameObject);
                    setActualHealth(ally4Stats.gameObject);
                    allyList.Add(ally1Stats);
                    allyList.Add(ally2Stats);
                    allyList.Add(ally3Stats);
                    allyList.Add(ally4Stats);
                    ally1.SetActive(true);
                    ally2.SetActive(true);
                    ally3.SetActive(true);
                    ally4.SetActive(true);
                    break;
                default:
                    Debug.Log("ERROR : Can't have this number of allies.");
                    break;
            }
        }

        List<EntityStats> enemyList = new List<EntityStats>();
        int enemyDamage = (int)(Math.Pow(requireLvl,3)*0.2);
        int enemyHealth = (int)Math.Pow(requireLvl,3);
        switch(numberEnemy)
        {
            case 1:
                enemy1Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                setActualHealth(enemy1Stats.gameObject);
                enemyList.Add(enemy1Stats);
                break;
            case 2:
                enemy1Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy2Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                setActualHealth(enemy1Stats.gameObject);
                setActualHealth(enemy2Stats.gameObject);
                enemyList.Add(enemy1Stats);
                enemyList.Add(enemy2Stats);
                enemy2.SetActive(true);
                break;
            case 3:
                enemy1Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy2Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy3Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                setActualHealth(enemy1Stats.gameObject);
                setActualHealth(enemy2Stats.gameObject);
                setActualHealth(enemy3Stats.gameObject);
                enemyList.Add(enemy1Stats);
                enemyList.Add(enemy2Stats);
                enemyList.Add(enemy3Stats);
                enemy2.SetActive(true);
                enemy3.SetActive(true);
                break;
            case 4:
                enemy1Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy2Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy3Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy4Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                setActualHealth(enemy1Stats.gameObject);
                setActualHealth(enemy2Stats.gameObject);
                setActualHealth(enemy3Stats.gameObject);
                setActualHealth(enemy4Stats.gameObject);
                enemyList.Add(enemy1Stats);
                enemyList.Add(enemy2Stats);
                enemyList.Add(enemy3Stats);
                enemyList.Add(enemy4Stats);
                enemy2.SetActive(true);
                enemy3.SetActive(true);
                enemy4.SetActive(true);
                break;
            case 5:
                enemy1Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy2Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy3Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy4Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                enemy5Stats.setStats(enemyHealth,enemyDamage,requireLvl);
                setActualHealth(enemy1Stats.gameObject);
                setActualHealth(enemy2Stats.gameObject);
                setActualHealth(enemy3Stats.gameObject);
                setActualHealth(enemy4Stats.gameObject);
                setActualHealth(enemy5Stats.gameObject);
                enemyList.Add(enemy1Stats);
                enemyList.Add(enemy2Stats);
                enemyList.Add(enemy3Stats);
                enemyList.Add(enemy4Stats);
                enemyList.Add(enemy5Stats);
                enemy2.SetActive(true);
                enemy3.SetActive(true);
                enemy4.SetActive(true);
                enemy5.SetActive(true);
                break;
            default:
                Debug.Log("ERROR : Can't have this number of enemies.");
                break;
        }
        StartCoroutine(wait(enemyList,allyList,numberEnemy));
    }

    void Update()
    {
        float movespeed = 10f;
        float step = movespeed * Time.deltaTime;

        if(playerAttacking)
        {
            if(pos.position == enemyPos.position){
                pos.position = lastPlayerPos;
                playerAttacking = false;
                tmp.takeDamage(playerStats.getDamage());
                setActualHealth(tmp.gameObject);
                Debug.Log("L'ennemi n'a plus que :"+tmp.getHealth().ToString());
            }else{
                pos.position = Vector2.MoveTowards(pos.position, enemyPos.position, step);
                pos.right = enemyPos.position - pos.position;
                //float x = lastPlayerPos.x + frame*movespeed;
                //float y = (float)(-1*Math.Pow(frame-((enemyPos.position.x-lastPlayerPos.x)/2),2)+Math.Pow(((enemyPos.position.x-lastPlayerPos.x)/2),2)-(Math.Pow(Math.Pow((enemyPos.position.y/lastPlayerPos.y),2),0.5)*frame));
                //Debug.Log(x);
                //Debug.Log(y);
                //player.transform.position = new Vector2(x/100000,y/100000);
                //frame++;
            }
        }

        if(enemyAttacking)
        {
            if(enemyPos.position == pos.position){
                enemyPos.position = lastEnemyPos;
                enemyAttacking = false;
                playerStats.takeDamage(enemyA.getDamage());
                setActualHealth(player);
                Debug.Log("Le joueur n'a plus que "+playerStats.getHealth().ToString());
            }else{
                enemyPos.position = Vector2.MoveTowards(enemyPos.position, pos.position, step);
                enemyPos.right = enemyPos.position - pos.position;
            }
        }

        if(allyAttacking)
        {
            if(allyPos.position == enemyPos.position){
                allyPos.position = lastAllyPos;
                allyAttacking = false;
                tmp.takeDamage(playerStats.getDamage());
                setActualHealth(tmp.gameObject);
                Debug.Log("L'ennemi n'a plus que :"+tmp.getHealth().ToString());
            }else{
                allyPos.position = Vector2.MoveTowards(allyPos.position, enemyPos.position, step);
                allyPos.right = enemyPos.position - allyPos.position;
            }
        }
    }

    IEnumerator wait(List<EntityStats> enemyList,List<EntityStats> allyList, int cpt_enemy_alive)
    {
        playerAttacking = false;
        enemyAttacking = false;
        allyAttacking = false;
        pos = player.transform;
        lastPlayerPos = pos.position;

        while(cpt_enemy_alive > 0 && playerStats.isAlive())
        {
            int index = UnityEngine.Random.Range(0,enemyList.Count);
            tmp = enemyList[index];
            enemyPos = tmp.transform.gameObject.transform;
            Debug.Log("Le joueur attaque");
            playerAttacking = true;
            yield return new WaitForSeconds(2);
            if(!tmp.isAlive())
            {
                Debug.Log("Un ennemy est mort");
                enemyList.Remove(tmp);
                tmp.transform.gameObject.SetActive(false);
                cpt_enemy_alive--;
            }
            if(cpt_enemy_alive == 0)break;
            foreach (var ally in allyList)
            {
                index = UnityEngine.Random.Range(0,enemyList.Count);
                tmp = enemyList[index];
                enemyPos = tmp.transform.gameObject.transform;
                allyPos = ally.transform.gameObject.transform;
                lastAllyPos = allyPos.position;
                Debug.Log("L'allié attaque");
                allyAttacking = true;
                yield return new WaitForSeconds(2);
                if(!tmp.isAlive())
                {
                    Debug.Log("Un ennemy est mort");
                    enemyList.Remove(tmp);
                    tmp.transform.gameObject.SetActive(false);
                    cpt_enemy_alive--;
                }
                if(cpt_enemy_alive == 0)break;
            }
            if(cpt_enemy_alive == 0)break;
            foreach (var enemy in enemyList)
            {
                enemyA = enemy;
                enemyPos = enemy.transform.gameObject.transform;
                lastEnemyPos = enemyPos.position;
                Debug.Log("L'ennemi attaque");
                enemyAttacking = true;
                yield return new WaitForSeconds(2);
                if(!playerStats.isAlive())
                {
                    break;
                }
            }
        }
        Debug.Log("Le combat est terminé");
        endWindow.SetActive(true);
        GameObject exp = endWindow.transform.GetChild(0).GetChild(1).GetChild(0).gameObject;
        GameObject items = endWindow.transform.GetChild(0).GetChild(1).GetChild(1).gameObject;
        GameObject finalText = endWindow.transform.GetChild(0).GetChild(0).gameObject;
        if(cpt_enemy_alive == 0)
        {
            int experience = playerLevel*numberEnemy*requireLvl*difficulty;
            exp.transform.GetComponent<UnityEngine.UI.Text>().text = "Vous avez gagné "+ experience.ToString() +" xp";

            List<string> loots = quest.loots;
            int chance = UnityEngine.Random.Range(0,100); 
            if(chance > 5)
            {
                items.transform.GetComponent<UnityEngine.UI.Text>().text = "Vous n'avez rien gagné !";
            }else{
                if(loots.Count != 0)
                {
                    int rdm_loot = UnityEngine.Random.Range(0,loots.Count);
                    string loot = loots[rdm_loot];
                    items.transform.GetComponent<UnityEngine.UI.Text>().text = "Vous avez gagné : "+loot;
                    PlayerPrefs.SetString("loot",loot);
                }else{
                    items.transform.GetComponent<UnityEngine.UI.Text>().text = "Vous n'avez rien gagné !";
                }
            }
            if(playerReqExp > experience+playerCurrExp)
            {
                playerCurrExp += experience;
            }else{
                while(playerReqExp < experience+playerCurrExp)
                {
                    playerLevel++;
                    PlayerPrefs.SetInt("damage",(int)(Math.Pow(playerLevel,3)*0.2));
                    PlayerPrefs.SetInt("health",(int)Math.Pow(playerLevel,3));
                    experience -= playerReqExp - playerCurrExp;
                    playerCurrExp = 0;
                    playerReqExp = (int)(Math.Exp(playerLevel/5)+Math.Pow(playerLevel,3));
                }
                playerCurrExp = experience;
            }
            finalText.transform.GetComponent<UnityEngine.UI.Text>().text = "You Win !";

            PlayerPrefs.SetInt("level",playerLevel);
            PlayerPrefs.SetInt("currExp",playerCurrExp);
            PlayerPrefs.SetInt("reqExp",playerReqExp);
            if(questKind == "Story")
            {
                PlayerPrefs.SetInt("story", actual_story+1);
            }

        }else{
            finalText.transform.GetComponent<UnityEngine.UI.Text>().text = "You Lose !";
            exp.transform.GetComponent<UnityEngine.UI.Text>().text = "Vous n'avez rien gagné !";
            items.transform.GetComponent<UnityEngine.UI.Text>().text = "";
        }
    }

    public void setActualHealth(GameObject entity)
    {
        entity.transform.GetChild(0).GetChild(2).GetComponent<UnityEngine.UI.Text>().text = entity.GetComponent<EntityStats>().getHealth().ToString();
    }
}
