using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectEnabler : MonoBehaviour
{
    public GameObject obj;
    public OVRInput.Button button = OVRInput.Button.Three;
    bool pressedLastFrame = false;

    void Start()
    {
        obj.SetActive(false);
    }

    void Update()
    {
        if(OVRInput.Get(button) && !pressedLastFrame) obj.SetActive(!obj.activeInHierarchy);

        pressedLastFrame = OVRInput.Get(button);
    }
}