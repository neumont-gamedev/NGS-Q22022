using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StopHeadsetWallClipping : MonoBehaviour
{
    public GameObject wallColliderSphere;
    public GameObject bohCollider;
    public BackOfHeadCollider bohScript;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            wallColliderSphere.GetComponent<MeshRenderer>().enabled = true;
            bohCollider.GetComponent<BoxCollider>().enabled = true;
            print("enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground" && bohScript.safeToExit == true)
        {
            wallColliderSphere.GetComponent<MeshRenderer>().enabled = false;
            bohCollider.GetComponent<BoxCollider>().enabled = false;
            print("exit");
        }
    }
}
