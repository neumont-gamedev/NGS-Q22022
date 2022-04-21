using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMarker : MonoBehaviour
{
    public GameObject worldObject;
    public Image image;
    public RectTransform rectTransform;
    public string objectTag = "Player";
    public Color markerColor = Color.white;

    protected float markerZ = 0f;

    protected void Start()
    {
        if (worldObject == null) worldObject = GameObject.FindWithTag(objectTag);
        if (image == null) image = GetComponent<Image>();
        if (rectTransform == null) rectTransform = gameObject.GetComponent<RectTransform>();

        markerZ = rectTransform.localPosition.z;
        image.color = markerColor;

        if (!(this is PlayerMarker))
        {
            markerZ = FindObjectOfType<PlayerMarker>().rectTransform.localPosition.z;
        }
    }

    public void UpdatePosition(KeyValuePair<float,float> values)
    {
        if (rectTransform == null) rectTransform = gameObject.GetComponent<RectTransform>();
        //rectTransform.position = new Vector3(values.Key, values.Value, 0);
        rectTransform.localPosition = new Vector3(values.Key, values.Value, markerZ);
        Debug.Log(rectTransform.position.x + " " + rectTransform.position.y);
        Debug.Log(values.Key + " " + values.Value);
    }
    public void RemoveMarker()
    {
        Destroy(gameObject);
    }
}
