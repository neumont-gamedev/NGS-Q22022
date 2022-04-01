using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HammerEnabler : MonoBehaviour
{

    public GameObject hammer;
    bool hammerOn;
    // Start is called before the first frame update
    void Start()
    {
        hammer.SetActive(false);
        hammerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.Three))
        {
            if(hammerOn)
            {
                hammer.SetActive(false);
                hammerOn = false;
            }
            else
            {
                hammer.SetActive(true);
                hammerOn = true;
            }
        }
    }
}
