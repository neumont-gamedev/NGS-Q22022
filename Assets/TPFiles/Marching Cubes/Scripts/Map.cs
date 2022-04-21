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

    NoiseManager noiseManager;
    List<MapMarker> markers = new List<MapMarker>();

    private void Awake()
    {
        noiseManager = FindObjectOfType<NoiseManager>();
        noiseManager.map = this;
    }

    public void GenerateMap()
    {
        foreach(var i in noiseManager.getCoords())
        {
            GameObject remake = Instantiate(mapMarker, panel.transform);
            remake.GetComponent<MapMarker>().UpdatePosition(i);
            markers.Add(remake.GetComponent<MapMarker>());
        }

        Instantiate(boardMarker, panel.transform);
        markers.Add(boardMarker.GetComponent<PlayerMarker>());

        Instantiate(playerMarker, panel.transform);
        markers.Add(playerMarker.GetComponent<PlayerMarker>());
        Debug.LogWarning("Map Generated");
    }
}
