using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectEnabler : MonoBehaviour
{
    public AudioSource itemSwitch;
    public GameObject[] objects;
    public GameObject[] toolDescriptionPanels;
    public GameObject goHUD;
    public GameObject controller;
    public OVRInput.Button button = OVRInput.Button.Three;
    public OVRInput.Button buttonTools = OVRInput.Button.Two;
    bool pressedLastFrame = false;
    bool buttonToolsPLF = false; //PLF = Pressed Last Frame
    public bool inLab = true;
    public float delayTime = 0.3f;
    float timer = 0;
    bool timerOn = false;
    bool playItemNextFrame = false;
    bool reset = false;


    int counter = 0;
    int descriptionCounter = 0;

    void Awake()
    {
        foreach (GameObject obj in objects) { obj.SetActive(false); }
        foreach (GameObject panel in toolDescriptionPanels) { panel.SetActive(false); }

        controller.SetActive(true);
    }

    void Update()
    {
        if ((OVRInput.Get(button) && !pressedLastFrame) || Input.GetKeyDown(KeyCode.Q))
        {
            reset = false;
            timerOn = true;
            timer = delayTime;
        }
        if(timerOn && ((OVRInput.Get(button) && OVRInput.Get(buttonTools)) || Input.GetKeyDown(KeyCode.E)))
        {
            timerOn = false;
            if (goHUD.GetComponent<Canvas>().enabled)
            {
                goHUD.GetComponent<Canvas>().enabled = false;
            }
            else
            {
                goHUD.GetComponent<Canvas>().enabled = true;
            }

            controller.SetActive(false);
            objects[counter].SetActive(false);
        }
        else if(playItemNextFrame)
        {
            playItemNextFrame = false;
            if (counter < objects.Length)
            {
                if (inLab)
                {
                    objects[counter].SetActive(true);
                    controller.SetActive(false);
                    if (counter - 1 >= 0)
                    {
                        objects[counter - 1].SetActive(false);
                    }
                    counter++;
                }
                else
                {
                    controller.SetActive(true);
                    counter = 0;
                    reset = true;
                }
            }
            else
            {
                if (counter - 1 >= 0) objects[counter - 1].SetActive(false);

                controller.SetActive(true);
                counter = 0;
                reset = true;
            }

            if (descriptionCounter < toolDescriptionPanels.Length)
            {
                if (toolDescriptionPanels[descriptionCounter] != null) toolDescriptionPanels[descriptionCounter].SetActive(true);

                if (descriptionCounter - 1 >= 0)
                {
                    if (toolDescriptionPanels[descriptionCounter - 1] != null) toolDescriptionPanels[descriptionCounter - 1].SetActive(false);
                }

                descriptionCounter++;
            }
            else
            {
                if (descriptionCounter - 1 >= 0)
                {
                    if (toolDescriptionPanels[descriptionCounter - 1] != null) toolDescriptionPanels[descriptionCounter - 1].SetActive(false);
                }

                if (reset)
                {
                    descriptionCounter = 0;
                    reset = false;
                }
            }

            itemSwitch?.Play();
        }
        if(timerOn)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                timerOn = false;
                playItemNextFrame = true;
            }
        }

        pressedLastFrame = OVRInput.Get(button) || OVRInput.Get(buttonTools);
    }
}