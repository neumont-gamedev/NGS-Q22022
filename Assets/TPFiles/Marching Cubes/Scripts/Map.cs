using MarchingCubes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject playerMarker;
    public GameObject boardMarker;
    public GameObject mapMarker;
    public GameObject panel;

    List<MapMarker> markers = new List<MapMarker>();

    public void GenerateMap()
    {
        foreach(var i in FindObjectOfType<NoiseManager>().getCoords())
        {
            GameObject markerClone = Instantiate(mapMarker, panel.transform);
            markerClone.GetComponent<MapMarker>().UpdatePosition(i);
            markers.Add(markerClone.GetComponent<MapMarker>());
        }

        Instantiate(boardMarker, panel.transform);
        markers.Add(boardMarker.GetComponent<MapMarker>());

        Instantiate(playerMarker, panel.transform);
        markers.Add(playerMarker.GetComponent<PlayerMarker>());
        Debug.LogWarning("Map Generated");
    }
}
