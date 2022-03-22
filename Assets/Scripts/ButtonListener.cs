using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonListener : MonoBehaviour
{

    public Button shopButton;
    public Button statsButton;
    public Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        shopButton.onClick.AddListener(TaskOnClick);
        statsButton.onClick.AddListener(TaskOnClick);
        settingsButton.onClick.AddListener(TaskOnClick);      
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene(2);
    }

}
