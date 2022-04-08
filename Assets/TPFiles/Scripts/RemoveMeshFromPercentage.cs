using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveMeshFromPercentage : MonoBehaviour
{
    public GameObject[] Meshes;
    public GameObject ObjectWithMesh;
    public float percentageAmount = 100;

    public Camera mainCamera;
    private RaycastHit raycastHit;
    public int clickAmount = 0;

    public GameObject dustParticle;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.gameObject.name == "ObjectWithMesh")
                {
                    Debug.Log("clicked " + clickAmount + " times.");
                    clickAmount++;

                    GameObject dust = Instantiate(dustParticle, raycastHit.transform);

                    Destroy(dust, 2f);
                }
            }
        }

        #region Testing Mesh Changes
        //percentageAmount -= Time.deltaTime;
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
        #endregion
    }
}
