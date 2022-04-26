using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fossil : MonoBehaviour
{
    private bool unburied = false;
    private bool buried = true;
    private bool startDigging = false;

    private OVRGrabbable grabbable;
    private Animator ani;
    private GameObject shell;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        grabbable = GetComponent<OVRGrabbable>();
        shell = transform.Find("Shell").gameObject;
        shell.SetActive(false);
        grabbable.enabled = false;
        //Plaster();
    }

    //resets buried to false until it comes back false
    private void FixedUpdate()
    {
        if (startDigging)
        {
            if (!buried)
            {
                unburied = true;
                FossilHolder.FossilFound(this);
                //Debug.Log("Bruh it works");
            }
            if (!unburied)
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
            if (!unburied)
            {
                buried = true;
            }
        }
    }

    //changes buried true as long as they collide
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" && !unburied)
        {
            buried = true;
        }
    }

    public bool isFound() { return unburied; }

    public void Plaster()
    {
        shell.SetActive(true);
        ani.Play("FieldJacketClose");
    }

    public void PlasterDone()
    {
        grabbable.enabled = true;
    }
}
