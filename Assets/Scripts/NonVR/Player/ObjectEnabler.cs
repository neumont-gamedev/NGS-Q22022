using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectEnabler : MonoBehaviour
{
    public AudioSource itemSwitch;
    public GameObject[] objects;
    public GameObject[] toolDescriptionPanels;
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
        foreach (GameObject panel in toolDescriptionPanels)
        {
            panel.SetActive(false);
        }

        if (controller == null) controller = GameObject.Find("RightControllerAnchor");
        if (itemSwitch == null) itemSwitch = GetComponent<AudioSource>();
        controller.SetActive(true);
    }

    void Update()
    {
        if ((OVRInput.Get(button) && !pressedLastFrame) || Input.GetKeyDown(KeyCode.Space))
        {
            if(counter < objects.Length)
            {
                objects[counter].SetActive(true);
                if(toolDescriptionPanels.Length >= counter)
                {
                    toolDescriptionPanels[counter].SetActive(true);
                }

                controller.SetActive(false);
                if(counter - 1 >= 0)
                {
                    objects[counter - 1].SetActive(false);
                    if(counter - 1 < toolDescriptionPanels.Length)
                    {
                        toolDescriptionPanels[counter - 1].SetActive(false);
                    }
                }

                counter++;
            }
            else
            {
                if (counter - 1 >= 0)
                {
                    objects[counter - 1].SetActive(false);

                    if (counter - 1 < toolDescriptionPanels.Length)
                    {
                        if(toolDescriptionPanels[counter - 1] != null) toolDescriptionPanels[counter - 1].SetActive(false);
                    }
                }
                controller.SetActive(true);
                counter = 0;
            }
            itemSwitch?.Play();
        }        

        pressedLastFrame = OVRInput.Get(button);
    }
}