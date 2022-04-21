using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will Be Child Class of MapMarker
public class PlayerMarker : MapMarker
{
    public GameObject worldObject;
    public string objectTag = "Player";

    private new void Start()
    {
        base.Start();
        SetPositionAndRotation();
        if (worldObject == null) worldObject = GameObject.FindWithTag(objectTag);
    }

    void Update()
    {
        SetPositionAndRotation();
    }

    void SetPositionAndRotation()
    {
        rectTransform.localPosition = new Vector3(worldObject.transform.position.x / 100f, worldObject.transform.position.z / 100f, markerZ);
        rectTransform.localRotation = Quaternion.Euler(0f, 0f, -worldObject.transform.rotation.eulerAngles.y);
    }
}
