using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject LoadingRaptor;
    public OVRPlayerController playerController;

    void Awake()
    {
        if (playerController != null) playerController.enabled = false;
        StartCoroutine(LoadingScreenCo());
    }

    IEnumerator LoadingScreenCo()
    {
        yield return new WaitForSeconds(5);
        LoadingRaptor.SetActive(false);
        LoadingScreen.SetActive(false);
        if (playerController != null) playerController.enabled = true;
        yield return true;
    }
}
