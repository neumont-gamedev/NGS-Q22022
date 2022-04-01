using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{

    public GameObject LoadingScreen;
    public GameObject LoadingRaptor;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingScreenCo());
    }


    IEnumerator LoadingScreenCo()
    {
        yield return new WaitForSeconds(5);
        LoadingRaptor.SetActive(false);
        LoadingScreen.SetActive(false);
        yield return true;
    }
}
