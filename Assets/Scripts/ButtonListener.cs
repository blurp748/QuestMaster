using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonListener : MonoBehaviour
{

    public Button mergeButton;
    public Button statsButton;
    public Button settingsButton;

    // Start is called before the first frame update
    void Start()
    {
        mergeButton.onClick.AddListener(GoToMerge);
        statsButton.onClick.AddListener(TaskOnClick);
        settingsButton.onClick.AddListener(TaskOnClick);      
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene(2);
    }

    private void GoToMerge()
    {
        SceneManager.LoadScene(3);
    }

}
