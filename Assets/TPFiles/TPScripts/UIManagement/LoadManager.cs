using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes;

public class LoadManager : MonoBehaviour
{
    public GameObject LoadingScreen;
    public GameObject HUD;
    public OVRPlayerController playerController;
    public bool activateHUD = true;

    ObjectEnabler[] enablers;

    public ChunkLoad chunkLoad;
    [Serializable]
    public class ChunkLoad
    {
        public bool waitForChunks = true;
        public int startingChunkX = 1;
        public int startingChunkY = -1;
    }

    void Awake()
    {
        playerController = GetComponentInParent<OVRPlayerController>();
        if (playerController != null) playerController.enabled = false;
        if (enablers == null || enablers.Length == 0) enablers = GetComponentsInParent<ObjectEnabler>();

        ActivateObjectEnablers(false);
        HUD.SetActive(false);

        StartCoroutine(LoadingScreenCo());
    }

    IEnumerator LoadingScreenCo()
    {
        if (chunkLoad.waitForChunks) // IsPlayerSet is based on ChunkManager
        {
            yield return WaitUntilTrue(IsPlayerSet);
            yield return WaitUntilTrue(IsEnoughChunksLoaded);
        }
        else yield return new WaitForSeconds(2);

        LoadingScreen.SetActive(false);
        if (activateHUD) HUD.SetActive(true);
        if (playerController != null) playerController.enabled = true;
        ActivateObjectEnablers(true);

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
        return ChunkManager.Instance.Player != null;
    }

    bool IsEnoughChunksLoaded()
    {
        List<GameObject> chunks = new List<GameObject>();
        GameObject chunk;
        int i, j;
        for (i = chunkLoad.startingChunkX - 1; i < chunkLoad.startingChunkX + 2; i++)
        {
            for (j = chunkLoad.startingChunkY - 1; j < chunkLoad.startingChunkY + 2; j++)
            {
                chunk = GameObject.Find($"Chunk_{i}|{j}");
                if (chunk != null)
                {
                    chunks.Add(chunk);
                }
                else return false;
            }
        }

        return true;
    }

    private void ActivateObjectEnablers(bool activate)
    {
        if (enablers != null && enablers.Length > 0)
        {
            foreach (var enabler in enablers)
            {
                enabler.enabled = activate;
            }
        }
    }
}
