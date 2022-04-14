using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : MonoBehaviour
{

    int stage = 0;

    public void ChangeColor()
    {

        this.GetComponent<Renderer>().material.color = new Color(0, 204, 102);
        Debug.Log("Change Color");

        /*       
                stage++;
                switch (stage)
                {
                    case 1:
                        this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                        break;
                    case 2:
                        this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
                        break;
                    case 3:
                        this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                        break;
                    default:
                        break;
                }
        */
    }
}
