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
        foreach(var f in FindObjectOfType<NoiseManager>().fossils)
        {
            foreach (var i in FindObjectOfType<NoiseManager>().getCoords())
            {
                if(f.transform.position.x == i.Key && f.transform.position.z == i.Value)
                {
                    GameObject markerClone = Instantiate(mapMarker, panel.transform);
                    markerClone.GetComponent<MapMarker>().UpdatePosition(i);
                    markerClone.GetComponent<MapMarker>().fossil = f.GetComponent<Fossil>();
                    markers.Add(markerClone.GetComponent<MapMarker>());
                }
            }
        }

        GameObject boardClone = Instantiate(boardMarker, panel.transform);
        var board = GameObject.FindGameObjectWithTag("Board").transform.position;
        boardClone.GetComponent<MapMarker>().UpdatePosition(new KeyValuePair<float, float>(board.x, board.z));
        markers.Add(boardClone.GetComponent<MapMarker>());

        Instantiate(playerMarker, panel.transform);
        markers.Add(playerMarker.GetComponent<PlayerMarker>());
    }
}
