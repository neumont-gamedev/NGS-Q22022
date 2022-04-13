using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fossil : MonoBehaviour
{
    public bool wasFound = false;
    public bool buried = true;
    public string name = null;

    private bool startDigging = false;

    //happens before the collisions
    private void FixedUpdate()
    {
        if (startDigging)
        {
            if (!buried)
            {
                wasFound = true;
                Debug.Log("Bruh it works");
            }
            if (!wasFound)
            {
                buried = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!startDigging)
            {
                startDigging = true;
            }
            if (!wasFound)
            {
                buried = true;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" && !wasFound)
        {
            buried = true;
        }
    }
}
