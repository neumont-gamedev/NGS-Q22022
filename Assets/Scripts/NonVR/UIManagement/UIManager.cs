using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //panel index checks with gamestate index
    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject infoBookPanel;

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

    #endregion

    #region UI Menus
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
        if (infoBookPanel.activeInHierarchy)
        {
            DeactivatePanel(infoBookPanel);
        }
        else if (infoBookPanel != null)
        {
            ActivatePanel(infoBookPanel);
        }
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
