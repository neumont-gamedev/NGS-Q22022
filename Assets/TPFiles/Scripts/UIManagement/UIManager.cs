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

    //Activates or Deactivates panel
    //based on current state
    public void SwitchActivity(GameObject panel)
    {
        if (panel.activeInHierarchy) panel.SetActive(false);
        else panel.SetActive(true);
    }

    //Makes give panel the only activate one
    public void ActivatePanel(GameObject panel)
    {
        DeactivatePanels();
        panel.SetActive(true);
    }

    //Deactivates all panels
    public void DeactivatePanels()
    {
        foreach(var p in panels) p.SetActive(false);
    }

    //Changes Objective based on fossil count
    public void ObjectiveChange()
    {
        if (FossilHolder.backpack.Count == 0)
        {
            txtObjective.text = "Go find a fossil!";
        }
        else
        {
            txtObjective.text = "Go clean your fossil!";
        }
    }

    //checks to see if player can enter lab
    //based on if they have any fossils to clean
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

    //Changes current obejctive in digging scene
    //Based on what step of the process your in
    public void DiggingObjective(int step)
    {
        switch (step) 
        {
            case 0:
                txtObjective.text = "Use map to find a fossil";
                break;
            case 1:
                txtObjective.text = "Completely uncover fossil";
                break;
            case 2:
                txtObjective.text = "Apply Plaster Strip";
                break;
            case 3:
                txtObjective.text = "Return to lab or Find more fossils";
                break;
        }
    }
}
