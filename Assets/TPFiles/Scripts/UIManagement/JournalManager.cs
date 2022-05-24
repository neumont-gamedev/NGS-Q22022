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

    public GameObject nextTab;
    public GameObject backTab;
    public GameObject identifyTab;
    public GameObject identifyBackTab;

    public Identify identifier;

    public List<GameObject> handColliders;

    public void Reset()
    {
        identifyOnPage.SetActive(false);
        identifyOffPage.SetActive(false);
        nextTab.SetActive(true);
        backTab.SetActive(true);
        identifyBackTab.SetActive(false);
        identifyTab.SetActive(true);

        foreach (GameObject i in journalPages)
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
        nextTab.SetActive(false);
        backTab.SetActive(false);
        identifyBackTab.SetActive(true);
        identifyTab.SetActive(false);

        foreach (GameObject i in identifyPages)
        {
            i.SetActive(false);
        }

        identifyPage = 0;
        journalPages[page].SetActive(true);
    }

    public void TurnPage()
    {
        Debug.Log(journalPages.Count.ToString());
        StopPlayer(2);

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

        Debug.Log(identifyPage);

    }

    public void BackPage()
    {
         StopPlayer(2);
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

        foreach (GameObject i in journalPages)
        {

            i.SetActive(false);
        }

        if (IdentifyReady)
        {
            identifyOnPage.SetActive(true);
        }
        else
        {
            identifyOffPage.SetActive(true);
        }
    }

    public void EnterAnswer(string name)
    {

        identifier.InsertAnswer(name);
        TurnIdentifyPage();
        StopPlayer(2);
    }

    public IEnumerator StopPlayer(float seconds)
    {
        foreach(GameObject c in handColliders)
        {
            c.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        yield return new WaitForSeconds(seconds);

        foreach (GameObject c in handColliders)
        {
            c.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }


}
