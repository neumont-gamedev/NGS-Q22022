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
    public int ChangeMaterial()
    {
        int stage = 0;
        stage++;

        switch (stage)
        {
            case 1:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage1;
                return stage = 1;
            case 2:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage2;
                return stage = 2;
            case 3:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage3;
                return stage = 3;
            case 4:
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage4;
                return stage = 4;
        }

        return stage;

    }
}
