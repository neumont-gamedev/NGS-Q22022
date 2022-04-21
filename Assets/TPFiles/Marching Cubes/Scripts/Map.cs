using MarchingCubes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    NoiseManager noiseManager;
    public GameObject playerMarker;
    public GameObject mapMarker;
    List<MapMarker> markers = new List<MapMarker>();
    public GameObject panel;

    public void GenerateMap()
    {
        noiseManager = FindObjectOfType<NoiseManager>();
        foreach(var i in noiseManager.getCoords())
        {
            GameObject remake = Instantiate(mapMarker, panel.transform);
            remake.GetComponent<MapMarker>().UpdatePosition(i);
            markers.Add(remake.GetComponent<MapMarker>());
        }

        //Instantiate(playerMarker, panel.transform);
        //markers.Add(playerMarker.GetComponent<PlayerMarker>())
    }
}
