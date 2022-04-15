using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectEnabler : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject controller;
    public OVRInput.Button button = OVRInput.Button.Three;
    bool pressedLastFrame = false;

    int counter = 0;

    void Awake()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }

        if (controller == null) controller = GameObject.Find("RightControllerAnchor");
        controller.SetActive(true);
    }

    void Update()
    {
        if (OVRInput.Get(button) && !pressedLastFrame)
        {
            if (counter < objects.Length)
            {
                objects[counter].SetActive(true);
                controller.SetActive(false);
                if (counter-1 >= 0) objects[counter-1].SetActive(false);
                counter++;
            }
            else
            {
                objects[counter-1].SetActive(false);
                controller.SetActive(true);
                counter = 0;
            }
        }

        pressedLastFrame = OVRInput.Get(button);
    }
}