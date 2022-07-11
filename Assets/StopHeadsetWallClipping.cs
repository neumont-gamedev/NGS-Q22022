using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StopHeadsetWallClipping : MonoBehaviour
{
    public GameObject wallColliderSphere;
    public GameObject rayCastPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            wallColliderSphere.SetActive(true);
            print("enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        Vector3 fwd = rayCastPoint.transform.TransformDirection(Vector3.forward);

        if (other.gameObject.tag == "Ground" && Physics.Raycast(rayCastPoint.transform.position, fwd, 10))
        {
            wallColliderSphere.SetActive(false);
            print("exit");
        }
    }
}
