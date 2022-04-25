using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //panel index checks with gamestate index
    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject infoBook;

    /*
    void Start()
    {
        //Hot Fix For Missing Menu In Excavation Scene
        if (SceneManager.GetActiveScene().buildIndex == 1) return;

        foreach(GameObject panel in panels)
        {
            DeactivatePanel(panel);
        }
    }
    */

    #region Generic Methods
    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ActivatePanel(GameManager.GameState gameState)
    {
        if ((int)gameState >= panels.Length) return;
        panels[(int)gameState].SetActive(true);
    }

    public void DeactivatePanel(GameManager.GameState gameState)
    {
        if ((int)gameState >= panels.Length) return;
        panels[(int)gameState].SetActive(false);
    }
    #endregion

    #region UI Menus
    //Because this method was called every frame, it would result in panel flashing no matter what so I've updated some methods
    // to work around it
    public void Menu(GameManager.GameState gameState)
    {
        GameObject currentPanel = panels[(int)gameState];

        if (currentPanel.activeInHierarchy)
        {
            DeactivatePanel(currentPanel);
        }
        else if(currentPanel != null)
        {
            ActivatePanel(currentPanel);
        }
    }

    public void InfoBook()
    {
        if (infoBook.activeInHierarchy)
        {
            DeactivatePanel(infoBook);
        }
        else if (infoBook != null)
        {
            ActivatePanel(infoBook);
        }
    }

    public void SwitchPanel(int currentPanelIndex, int destinationPanelIndex)
    {
        //3, 4 - Table of Contents
        //5-13 - Dino Entries (Allo, baro, igua, lobo, ples, pter, tril, trex, utah)
        DeactivatePanel(panels[destinationPanelIndex]);
        ActivatePanel(panels[currentPanelIndex]);
    }

    #endregion

    #region Scene Loading
    // Scene Indices: Museum = 0, Digging = 1, Cleaning = 2
    public void LoadMuseum()
    {
        //load scene
        SceneManager.LoadScene(0);

        //load anything that needs to be loaded
    }

    public void LoadExcavation()
    {
        //load scene
        SceneManager.LoadScene(1);

        //load anything that needs to be loaded
    }

    public void LoadLab()
    {
        //load scene
        SceneManager.LoadScene(2);

        //load anything that needs to be loaded
    }
    #endregion
}
