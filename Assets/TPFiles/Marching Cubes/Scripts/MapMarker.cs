using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    public RectTransform rectTransform;
    public float mapScale = 100f;

    protected float markerZ = -0.51f;

    protected void Start()
    {
        if (rectTransform == null) rectTransform = gameObject.GetComponent<RectTransform>();
        GetComponent<Image>().color = Color.white;
    }

    public void UpdatePosition(KeyValuePair<float,float> values)
    {
        rectTransform.localPosition = new Vector3(values.Key / mapScale, values.Value / mapScale, markerZ);
        Debug.Log(rectTransform.position.x + " " + rectTransform.position.y);
        Debug.Log(values.Key + " " + values.Value);
    }

    public void RemoveMarker()
    {
        Destroy(gameObject);
    }
}
