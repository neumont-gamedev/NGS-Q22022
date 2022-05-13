using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //panel index checks with gamestate index
    [SerializeField] GameObject[] panels;
    [SerializeField] int mainMenuIndex = 3;

    public GameObject LabButton;
    public GameObject NoFossilsText;

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
        if ((int)gameState >= panels.Length || panels[(int)gameState] == null) return;
        panels[(int)gameState].SetActive(true);
    }

    public void DeactivatePanel(GameManager.GameState gameState)
    {
        if ((int)gameState >= panels.Length || panels[(int)gameState] == null) return;
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
        else
        {
            ActivatePanel(currentPanel);
        }
    }

    public void InfoBook()
    {
        if (panels[mainMenuIndex].activeInHierarchy)
        {
            DeactivatePanel(panels[mainMenuIndex]);
        }
        else
        {
            ActivatePanel(panels[mainMenuIndex]);
        }
    }

    public void SwitchPanel(int currentPanelIndex, int destinationPanelIndex)
    {
        // 3 - 4 : Table of Contents
        // 5 - 13 : Dino Entries (Allo, baro, igua, lobo, ples, pter, tril, trex, utah)
        DeactivatePanel(panels[currentPanelIndex]);
        ActivatePanel(panels[destinationPanelIndex]);
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
        //If player doesnt have a fossil
        // Deactivate Lab Button
        if (FossilHolder.backpack.Count == 0)
        {
            LabButton.SetActive(false);
            NoFossilsText.SetActive(true);
        }
        else
        {
            //Reactiveate Button if Button is disabled
            if (!LabButton.activeSelf)
            {
                LabButton.SetActive(true);
                NoFossilsText.SetActive(false);
            }

            //load scene
            SceneManager.LoadScene(2);

            //load anything that needs to be loaded
        }
    }
    #endregion
}
