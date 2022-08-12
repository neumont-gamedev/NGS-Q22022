using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOfHeadCollider : MonoBehaviour
{
    public bool safeToExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            safeToExit = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            safeToExit = true;
        }
    }
}
