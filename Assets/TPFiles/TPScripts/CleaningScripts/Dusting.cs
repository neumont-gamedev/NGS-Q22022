using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : MonoBehaviour
{

    int stage = 0;
    public GameObject breakParticle;
    public GameObject cBreakParticle;

    public Material stage1;
    public Material stage2;
    public Material stage3;
    public Material stage4;

    public void ChangeMaterial()
    {

        stage++;

        switch (stage)
        {
            case 1:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage1;
                
                break;
            case 2:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage2;
                break;
            case 3:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage3;
                break;
            case 4:
                this.GetComponent<Renderer>().material = stage4;
                break;
            default:
                break;
        }

    }
}