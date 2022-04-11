using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Scene Indices: Museum = 0, Digging = 1, Cleaning = 2

    //public GameObject biomeIcon1;
    //public GameObject biomeIcon2;
    //public GameObject mainTitle;
    //public GameObject biomeSelect;
    //public GameObject aboutPage;
    //public GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        //biomeIcon1.SetActive(false);
        //biomeIcon2.SetActive(true);
        //mainTitle.SetActive(true);
        //biomeSelect.SetActive(false);
        //aboutPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStart()
    {

    }

    public void ActivatePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void DeactivatePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void LoadMuseum()
    {
        //load scene
        SceneManager.LoadScene(0);

        //load anything that needs to be loaded
    }
}
