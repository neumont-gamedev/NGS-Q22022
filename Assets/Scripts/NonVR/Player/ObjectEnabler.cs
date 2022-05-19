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
    int descriptionCounter = 0;

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
            bool reset = false;
            if(counter < objects.Length)
            {
                objects[counter].SetActive(true);

                controller.SetActive(false);
                if(counter - 1 >= 0)
                {
                    objects[counter - 1].SetActive(false);
                }

                counter++;
            }
            else
            {
                if (counter - 1 >= 0) objects[counter - 1].SetActive(false);

                controller.SetActive(true);
                counter = 0;
                reset = true;
            }

            if(descriptionCounter < toolDescriptionPanels.Length)
            {
                if (toolDescriptionPanels[counter] != null) toolDescriptionPanels[counter].SetActive(true);
                
                if(descriptionCounter - 1  >= 0)
                {
                    if (toolDescriptionPanels[counter - 1] != null) toolDescriptionPanels[counter - 1].SetActive(false);
                }

                descriptionCounter++;
            }
            else
            {
                if(descriptionCounter -1 >= 0)
                {
                    if (toolDescriptionPanels[counter - 1] != null) toolDescriptionPanels[counter - 1].SetActive(false);
                }

                if (reset)
                {
                    descriptionCounter = 0;
                    reset = false;
                }
            }

            itemSwitch?.Play();
        }        

        pressedLastFrame = OVRInput.Get(button);
    }
}