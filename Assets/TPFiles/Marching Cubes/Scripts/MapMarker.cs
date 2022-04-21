using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    public RectTransform rectTransform;

    protected float markerZ = -0.51f;

    protected void Start()
    {
        GetComponent<Image>().color = Color.white;
    }

    public void UpdatePosition(KeyValuePair<float,float> values)
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(values.Key, values.Value, markerZ);
        Debug.Log(rectTransform.position.x + " " + rectTransform.position.y);
        Debug.Log(values.Key + " " + values.Value);
    }

    public void RemoveMarker()
    {
        Destroy(gameObject);
    }
}
