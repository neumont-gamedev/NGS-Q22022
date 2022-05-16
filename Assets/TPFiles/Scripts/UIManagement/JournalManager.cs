using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> journalPages;
    int page = 0;

    bool IdentifyReady = false;

    //identify pages
    public GameObject identifyOnPage;
    public GameObject identifyOffPage;

    public GameObject nextTab;
    public GameObject backTab;
    public GameObject identifyTab;
    public GameObject identifyBackTab;


    public void Reset()
    {
        identifyOnPage.SetActive(false);
        identifyOffPage.SetActive(false);
        nextTab.SetActive(true);
        backTab.SetActive(true);
        identifyTab.SetActive(true);

        foreach (GameObject i in journalPages)
        {
            
            i.SetActive(false);
        }


        page = 0;
        journalPages[page].SetActive(true);
    }

    public void TurnPage()
    {

        if(page + 1 > journalPages.Count)
        {
            Reset();
        }
        else
        {
            page++;
            journalPages[page].SetActive(true);
        }
        
    }

    public void BackPage()
    {

        if (page - 1 < 0)
        {
            Reset();
        }
        else
        {
            journalPages[page].SetActive(false);
            page--;
            journalPages[page].SetActive(true);
        }
    }

    public void GoToIdentify()
    {
        nextTab.SetActive(false);
        backTab.SetActive(false);
        identifyTab.SetActive(false);
        identifyBackTab.SetActive(true);

        if (IdentifyReady)
        {
            identifyOnPage.SetActive(true);
        }
        else
        {
            identifyOffPage.SetActive(true);
        }
    }



}
