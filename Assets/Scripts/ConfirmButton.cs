using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfirmButton : MonoBehaviour
{
    public Button button;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick); 
    }

    private void TaskOnClick()
    {
         SceneManager.LoadScene(0);
    }
}
