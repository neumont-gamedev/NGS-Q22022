using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : MonoBehaviour
{
    public int stageNum = 0;
    //public GameObject breakParticle;

    public List<Material> stages = new List<Material>();

    //public Material stage1;
    //public Material stage2;
    //public Material stage3;
    public Material stage4;
    public bool baseCleanDone = false;
    bool donePolishing = false;

    //Changes the material based on stage
    //Returns true when on final stage
    public bool ChangeMaterial()
    {
        if (!baseCleanDone)
        {
            if (stageNum < stages.Count)
            {
                
                switch (stageNum)
                {
                    case 1:
                        GetComponent<Renderer>().material = stages[stageNum];
                        stageNum++;
                        return false;
                    case 2:
                        GetComponent<Renderer>().material = stages[stageNum];
                        stageNum++;
                        return false;
                    case 3:
                        GetComponent<Renderer>().material = stages[stageNum];
                        baseCleanDone = true;
                        return true;
                    default:
                        break;
                }
            }
            return false;
        }
        return true;


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
