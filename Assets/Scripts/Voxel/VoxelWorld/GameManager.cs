using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    public void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneAt(0)) uiManager.ObjectiveChange();
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneAt(0) && SceneManager.GetActiveScene() != SceneManager.GetSceneAt(4)) uiManager.DiggingObjective(0);
    }

    //Build Reference: Museum=0 Dessert=1 Mountains=2 Riverbed=3 Lab=4
    public void LoadScene(int sceneIndex)
    {
        switch (sceneIndex)
        {
            case 0:
                SceneManager.LoadScene(0);
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

    //Quits game
    public void OnQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
