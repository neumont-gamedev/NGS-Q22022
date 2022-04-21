using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMarker : MonoBehaviour
{
    public void UpdatePosition(KeyValuePair<float,float> values)
    {
        RectTransform rec = gameObject.GetComponent<RectTransform>();
        rec.position = new Vector3(values.Key, values.Value, 0);
        Debug.Log(rec.position.x + " " + rec.position.y);
        Debug.Log(values.Key + " " + values.Value);
    }
    public void RemoveMarker()
    {
        Destroy(gameObject);
    }
}
