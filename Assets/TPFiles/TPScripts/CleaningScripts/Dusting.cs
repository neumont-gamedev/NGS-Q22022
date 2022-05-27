using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : MonoBehaviour
{
    public int stage = 0;
    public GameObject breakParticle;
    public GameObject cBreakParticle;

    public Material stage1;
    public Material stage2;
    public Material stage3;
    public Material stage4;

    bool donePolishing = false;

    //Changes the material based on stage
    //Returns true when on final stage
    public bool ChangeMaterial()
    {
        stage++;
        switch (stage)
        {
            case 1:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage1;
                return false;
            case 2:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage2;
                return false;
            case 3:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage3;
                return true;
            default:
                break;
        }

        return false;
    }

    //Polishes given material only once
    public bool PolishChange()
    {
        if (!donePolishing)
        {
            cBreakParticle = Instantiate(breakParticle);
            Destroy(cBreakParticle, 1.5f);
            this.GetComponent<Renderer>().material = stage4;
            donePolishing = true;
            return true;
        }
        return false;
    }
}
