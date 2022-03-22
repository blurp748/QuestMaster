using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManage : MonoBehaviour
{

    public GameObject levelText;
    public GameObject currExpText;
    public GameObject reqCurrExp;
    public GameObject health;
    public GameObject damage;


    // Start is called before the first frame update
    void Start()
    {
        levelText.GetComponent<Text>().text = "Level : "+PlayerPrefs.GetInt("level").ToString();
        currExpText.GetComponent<Text>().text = "Current exp : "+PlayerPrefs.GetInt("currExp").ToString();
        reqCurrExp.GetComponent<Text>().text = "Exp required : "+PlayerPrefs.GetInt("reqExp").ToString();
        health.GetComponent<Text>().text = "Health : "+PlayerPrefs.GetInt("health").ToString();
        damage.GetComponent<Text>().text = "Damage : "+PlayerPrefs.GetInt("damage").ToString();
    }
}
