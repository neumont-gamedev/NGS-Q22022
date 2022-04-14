using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes;

public class LoadManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject LoadingRaptor;
    public OVRPlayerController playerController;
    public ObjectEnabler enabler;

    int timer = 0;

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
        yield return WaitUntilTrue(IsPlayerSet);
        timer = 0;
        yield return WaitUntilTrue(IsEnoughChunksLoaded);
        LoadingRaptor.SetActive(false);
        LoadingScreen.SetActive(false);
        if (playerController != null) playerController.enabled = true;
        if (enabler != null) enabler.enabled = true;
        yield return true;
    }

    IEnumerator WaitUntilTrue(Func<bool> checkMethod)
    {
        while (checkMethod() == false)
        {
            yield return null;
        }
    }

    bool IsPlayerSet()
    {
#if UNITY_EDITOR
        timer++;
        Debug.LogWarning($"Player Timer: {timer}");
#endif
        return ChunkManager.Instance.Player != null;
    }

    bool IsEnoughChunksLoaded()
    {
#if UNITY_EDITOR
        timer++;
        Debug.LogWarning($"Chunk Timer: {timer}");
#endif
        List<GameObject> chunks = new List<GameObject>();
        GameObject chunk;
        int i, j;
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j > -3; j--)
            {
                chunk = GameObject.Find($"Chunk_{i}|{j}");
                if (chunk != null)
                {
                    chunks.Add(chunk);
                }
                else return false;
            }
        }
        Debug.LogWarning($"Chunks Size: {chunks.Count}");
        return true;
    }
}
