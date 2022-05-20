using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public void Start()
    {
        if (uiManager == null) uiManager = FindObjectOfType<UIManager>();
    }

    //0 - museum 1 - dessert  2 - mountains 3 - riverbed 4 - lab
    public void LoadScene(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 0:
                SceneManager.LoadScene(0);
                uiManager.ObjectiveChange();
                break;
            case 1:
                SceneManager.LoadScene(1);
                break;
            case 2:
                SceneManager.LoadScene(2);
                break;
            case 3:
                SceneManager.LoadScene(3);
                break;
            case 4:
                if(uiManager.LoadLab()) SceneManager.LoadScene(4);
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
