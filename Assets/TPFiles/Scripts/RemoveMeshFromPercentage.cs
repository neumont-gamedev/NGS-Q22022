using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMeshFromPercentage : MonoBehaviour
{
    public GameObject[] Meshes;
    public GameObject ObjectWithMesh;
    public float percentageAmount = 100;

    void Start()
    {
        
    }

    void Update()
    {
        percentageAmount -= Time.deltaTime;
        if (percentageAmount <= 0)
            percentageAmount = 0;

        if (percentageAmount < 75 && percentageAmount > 50)
        {
            ObjectWithMesh.GetComponent<MeshFilter>().mesh = Meshes[3].GetComponent<MeshFilter>().sharedMesh;
        }                                                                               
        else if (percentageAmount < 50 && percentageAmount > 25)                                                 
        {                                                                               
            ObjectWithMesh.GetComponent<MeshFilter>().mesh = Meshes[2].GetComponent<MeshFilter>().sharedMesh;
        }                                                                               
        else if (percentageAmount < 25 && percentageAmount > 0)                                                 
        {                                                                               
            ObjectWithMesh.GetComponent<MeshFilter>().mesh = Meshes[1].GetComponent<MeshFilter>().sharedMesh;
        }                                                                               
        else if (percentageAmount <= 0)                                                 
        {                                                                               
            ObjectWithMesh.GetComponent<MeshFilter>().mesh = Meshes[0].GetComponent<MeshFilter>().sharedMesh;
        }
    }
}
