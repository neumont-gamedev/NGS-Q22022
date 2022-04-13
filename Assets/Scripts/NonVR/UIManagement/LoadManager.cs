using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject LoadingRaptor;
    public OVRPlayerController playerController;
    public ObjectEnabler enabler;

    void Awake()
    {
        playerController = GetComponentInParent<OVRPlayerController>();
        if (enabler == null) enabler = GetComponentInParent<ObjectEnabler>();
        if (playerController != null) playerController.enabled = false;
        if (enabler != null) enabler.enabled = false;

        StartCoroutine(LoadingScreenCo());
    }

    IEnumerator LoadingScreenCo()
    {
        yield return new WaitForSeconds(5);
        LoadingRaptor.SetActive(false);
        LoadingScreen.SetActive(false);
        if (playerController != null) playerController.enabled = true;
        if (enabler != null) enabler.enabled = true;
        yield return true;
    }
}
