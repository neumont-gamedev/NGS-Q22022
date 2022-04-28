using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will Be Child Class of MapMarker
public class PlayerMarker : MapMarker
{
    public GameObject worldObject;

    private new void Start()
    {
        base.Start();
        if (worldObject == null) worldObject = GameObject.FindWithTag("Player");
        SetPosition();
    }

    void Update()
    {
        SetPosition();
        rectTransform.localRotation = Quaternion.Euler(0f, 0f, -worldObject.transform.rotation.eulerAngles.y);
    }

    void SetPosition()
    {
        rectTransform.localPosition = new Vector3(worldObject.transform.position.x / mapScale, worldObject.transform.position.z / mapScale, markerZ);
    }
}
