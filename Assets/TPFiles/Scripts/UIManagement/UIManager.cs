using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //panel index checks with gamestate index
    [SerializeField] GameObject[] panels;
    [SerializeField] int mainMenuIndex = 3;
    [SerializeField] TMP_Text txtObjective; 

    public GameObject LabButton;
    public GameObject NoFossilsText;

    #region Generic Methods
    public void SwitchActivity(GameObject panel)
    {
        if (panel.activeInHierarchy) panel.SetActive(false);
        else panel.SetActive(true);
    }

    public void ActivatePanel(GameObject panel)
    {
        DeactivatePanels();
        panel.SetActive(true);
    }

    public void DeactivatePanels()
    {
        foreach(var p in panels) p.SetActive(false);
    }
    #endregion

    #region UI Menus

    // Scene Indices: Museum = 0, Digging = 1, Cleaning = 2
    public void ObjectiveChange()
    {
        //load anything that needs to be loaded
        if (FossilHolder.backpack.Count == 0)
        {
            txtObjective.text = "Go find a fossil!";
        }
        else
        {
            txtObjective.text = "Go clean your fossil!";
        }
    }

    public bool LoadLab()
    {
        //If player doesnt have a fossil
        // Deactivate Lab Button
        if (FossilHolder.backpack.Count == 0)
        {
            LabButton.SetActive(false);
            NoFossilsText.SetActive(true);
            return false;
        }
        else
        {
            //Reactiveate Button if Button is disabled
            if (!LabButton.activeSelf)
            {
                LabButton.SetActive(true);
                NoFossilsText.SetActive(false);
            }
            return true;
        }
    }
    #endregion
}
