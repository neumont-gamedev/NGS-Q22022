using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fossil : MonoBehaviour
{
    public bool wasFound = false;
    public string name = null;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {

        }
    }
}
