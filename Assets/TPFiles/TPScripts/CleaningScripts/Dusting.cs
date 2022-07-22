using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : MonoBehaviour
{
    public int stage = 0;
    //public GameObject breakParticle;

    public List<Material> stages = new List<Material>();

    //public Material stage1;
    //public Material stage2;
    //public Material stage3;
    public Material stage4;

    bool donePolishing = false;

    //Changes the material based on stage
    //Returns true when on final stage
    public bool ChangeMaterial()
    {
        if(stage == 0)
        stage++;
        switch (stage)
        {
            case 1:
                GetComponent<Renderer>().material = stages[stage];
                return false;
            case 2:
                GetComponent<Renderer>().material = stages[stage];
                return false;
            case 3:
                GetComponent<Renderer>().material = stages[stage];
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
            GetComponent<Renderer>().material = stage4;
            donePolishing = true;
            return true;
        }
        return false;
    }
}
