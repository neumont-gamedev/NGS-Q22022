using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will Be Child Class of MapMarker
public class PlayerMarker : MapMarker
{
    public GameObject worldObject;
    public string objectTag = "Player";

    // isActualPlayer is false for BoardMarker; did not want to make a second script for this
    public bool isActualPlayer = true;

    private new void Start()
    {
        base.Start();
        if (worldObject == null) worldObject = GameObject.FindWithTag(objectTag);
        SetPosition();
    }

    void Update()
    {
        if (isActualPlayer) SetPositionAndRotation();
    }

    void SetPositionAndRotation()
    {
        SetPosition();
        SetRotation();
    }

    void SetPosition()
    {
        rectTransform.localPosition = new Vector3(worldObject.transform.position.x / mapScale, worldObject.transform.position.z / mapScale, markerZ);
    }

    void SetRotation()
    {
        rectTransform.localRotation = Quaternion.Euler(0f, 0f, -worldObject.transform.rotation.eulerAngles.y);
    }
}
