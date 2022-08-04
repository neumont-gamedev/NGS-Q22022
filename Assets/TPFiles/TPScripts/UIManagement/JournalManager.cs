using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JournalManager : MonoBehaviour
{
    public bool IdentifyReady = false;

    public List<GameObject> journalPages;
    public List<GameObject> identifyPages;
    int page = 0;
    int identifyPage = 0;

    //identify pages
    public GameObject identifyOnPage;
    public GameObject identifyOffPage;


    //Tabs
    public GameObject mainTabs;
    public GameObject identifyTabs;
    public GameObject identifyBack;

    //public GameObject mainNextTab;
    //public GameObject mainBackTab;
    //public GameObject enterIdentifyTab;
    //public GameObject identifyBackTab;

    //Clean check
    public bool identified = false;

    public JournalIdentify identifier;

    public List<GameObject> handColliders;

    public void Reset()
    {
        identifyOnPage.SetActive(false);
        identifyOffPage.SetActive(false);
        mainTabs.SetActive(true);
        identifyTabs.SetActive(false);
        identifyBack.SetActive(false);
        //mainNextTab.SetActive(true);
        //mainBackTab.SetActive(true);
        //identifyBackTab.SetActive(false);
        //enterIdentifyTab.SetActive(true);

        foreach (GameObject i in journalPages)
        {

            i.SetActive(false);
        }
        foreach (GameObject i in identifyPages)
        {

            i.SetActive(false);
        }

        page = 0;
        journalPages[page].SetActive(true);
    }

    public void IdentifyReset()
    {
        identifyOnPage.SetActive(true);
        identifyOffPage.SetActive(false);
        mainTabs.SetActive(false);
        identifyTabs.SetActive(true);
        identifyBack.SetActive(true);

        /*mainNextTab.SetActive(false);
        mainBackTab.SetActive(false);
        identifyBackTab.SetActive(true);
        enterIdentifyTab.SetActive(false);*/

        foreach (GameObject i in identifyPages)
        {
            i.SetActive(false);
        }

        identifyPage = 0;
        identifyPages[identifyPage].SetActive(true);
    }

    public void TurnPage()
    {
        Debug.Log(journalPages.Count.ToString());
        StartCoroutine(StopPlayer(2));

        if (page + 1 > journalPages.Count)
        {
            Reset();
        }
        else
        {
            page++;
            journalPages[page].SetActive(true);
        }

        Debug.Log(page);
        
    }

    public void TurnIdentifyPage()
    {

        if (identifyPage + 1 > identifyPages.Count)
        {
            IdentifyReset();
        }
        else
        {
            identifyPages[identifyPage].SetActive(false);
            identifyPage++;
            identifyPages[identifyPage].SetActive(true);
        }
        identifier.FillAnswers();
        Debug.Log(identifyPage);

    }

    public void BackPage()
    {
        StartCoroutine(StopPlayer(2));
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

    public void IdentifyBackPage()
    {
        StartCoroutine(StopPlayer(2));
        if (identifyPage - 1 < 0)
        {
            IdentifyReset();
        }
        else
        {
            identifyPages[identifyPage].SetActive(false);
            identifyPage--;
            identifyPages[identifyPage].SetActive(true);
        }
    }

    public void GoToIdentify()
    {
        mainTabs.SetActive(false);
        identifyTabs.SetActive(true);


       /* mainNextTab.SetActive(false);
        mainBackTab.SetActive(false);
        enterIdentifyTab.SetActive(false);
        identifyBackTab.SetActive(true);*/

        foreach (GameObject i in journalPages)
        {

            i.SetActive(false);
        }

        if (IdentifyReady)
        {
            identifyOnPage.SetActive(true);
            identifyBack.SetActive(true);
        }
        else
        {
            identifyOffPage.SetActive(true);
            identifyBack.SetActive(false);
        }
    }

    public void EnterAnswer(string name)
    {
        identified = true;
        identifier.InsertAnswer(name);
        TurnIdentifyPage();
        StartCoroutine(StopPlayer(2));
    }

    public IEnumerator StopPlayer(float seconds)
    {
        foreach(GameObject c in handColliders)
        {
            Debug.Log(c.name);
            c.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        yield return new WaitForSeconds(seconds);

        foreach (GameObject c in handColliders)
        {
            c.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }


}
