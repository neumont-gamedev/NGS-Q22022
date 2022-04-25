using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fossil : MonoBehaviour
{
    public bool wasFound = false;
    public bool buried = true;
    public string name = null;

    private bool startDigging = false;

    private Animator ani;
    private GameObject shell;

    //resets buried to false until it comes back false
    private void FixedUpdate()
    {
        if (startDigging)
        {
            if (!buried)
            {
                wasFound = true;
                FossilHolder.FossilFound(this);
                //Debug.Log("Bruh it works");
            }
            if (!wasFound)
            {
                buried = false;
            }
        }
    }

    //starts the digging and sets buried true
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

    //changes buried true as long as they collide
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" && !wasFound)
        {
            buried = true;
        }
    }

    public void Plaster()
    {
        shell.SetActive(true);
        ani.Play("FieldJacketClose");
    }
}
