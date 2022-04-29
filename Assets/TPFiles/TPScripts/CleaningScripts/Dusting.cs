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

    int timesCleaned = 0;
    public int ChangeMaterial(bool isCombined)
    {


        if (isCombined)
        {
            if(!donePolishing)
            {
                cBreakParticle = Instantiate(breakParticle);
                Destroy(cBreakParticle, 1.5f);
                this.GetComponent<Renderer>().material = stage4;
                donePolishing = true;
                return -1;
            }
        }

        else
        {
            Debug.Log(gameObject.name + " Stage: " + stage);
            stage++;
            switch (stage)
            {
                case 1:
                    cBreakParticle = Instantiate(breakParticle);
                    Destroy(cBreakParticle, 1.5f);
                    this.GetComponent<Renderer>().material = stage1;
                    return stage; //isCleaned false
                case 2:
                    cBreakParticle = Instantiate(breakParticle);
                    Destroy(cBreakParticle, 1.5f);
                    this.GetComponent<Renderer>().material = stage2;
                    return stage; //isCleaned false
                case 3:
                    cBreakParticle = Instantiate(breakParticle);
                    Destroy(cBreakParticle, 1.5f);
                    this.GetComponent<Renderer>().material = stage3;
                    return stage;
                default:
                    break;
            }
        }


        return stage;

    }
}
