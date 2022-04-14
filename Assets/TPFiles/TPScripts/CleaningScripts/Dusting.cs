using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : MonoBehaviour
{

    int stage = 0;

    public Material stage1;
    public Material stage2;
    public Material stage3;

    public void ChangeColor()
    {


        stage++;
        switch (stage)
        {
            case 1:
                this.GetComponent<Renderer>().material = stage1;
                break;
            case 2:
                this.GetComponent<Renderer>().material = stage2;
                break;
            case 3:
                this.GetComponent<Renderer>().material = stage3;
                break;
            default:
                break;
        }

    }
}
