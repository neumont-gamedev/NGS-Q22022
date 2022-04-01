using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrJump : MonoBehaviour
{
   public OVRPlayerController VRController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            VRController.Jump();
        }
    }
}
