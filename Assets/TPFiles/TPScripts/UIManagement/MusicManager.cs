using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    //Warning: Shuffle funcitonality is not implemented, due to not being required at current time, please adjust code if case is needed.
    private int currentTrack;
    
    [SerializeField]
    public bool PlayMusic;
    public List<AudioSource> trackList;


    public void Start()
    {
        if (PlayMusic)
        {
            currentTrack = 0;
            StartCoroutine(PlaySongCo());
        }
    }

    IEnumerator PlaySongCo()
    {
        //Warning: This Code does not cover the possibility on there being only 1 AudioSource in the trackList, Please adjust code if case is needed.
        while (PlayMusic)
        {
            trackList[currentTrack].Play();
            yield return new WaitForSeconds(trackList[currentTrack].clip.length);
            currentTrack++;
            if(currentTrack >= trackList.Count)
            {
                currentTrack = 0;
            }
        }
    }
}
