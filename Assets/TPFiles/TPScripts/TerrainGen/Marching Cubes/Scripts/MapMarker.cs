using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    public RectTransform rectTransform;
    public float mapScale = 100f;
    public Fossil fossil;

    protected float markerZ = -0.51f;

    protected void Start()
    {
        GetComponent<Image>().color = Color.white;
    }

    private void Update()
    {
        if(fossil == null)
        {
            RemoveMarker();
        }
    }

    public void UpdatePosition(KeyValuePair<float,float> values)
    {
        rectTransform.localPosition = new Vector3(values.Key / mapScale, values.Value / mapScale, markerZ);
    }

    public void RemoveMarker()
    {
        Destroy(gameObject);
    }
}
