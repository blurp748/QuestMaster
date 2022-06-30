using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonListener : MonoBehaviour
{

    public Button mergeButton;
    public Button statsButton;
    public Button leaveButton;

    // Start is called before the first frame update
    void Start()
    {
        mergeButton.onClick.AddListener(GoToMerge);
        statsButton.onClick.AddListener(TaskOnClick);
        leaveButton.onClick.AddListener(Leave);      
    }

    private void TaskOnClick()
    {
        SceneManager.LoadScene(2);
    }

    private void GoToMerge()
    {
        SceneManager.LoadScene(3);
    }

    private void Leave()
    {
        Application.Quit();
    }

}
