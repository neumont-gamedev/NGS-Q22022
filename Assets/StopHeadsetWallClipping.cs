using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class StopHeadsetWallClipping : MonoBehaviour
{
    public SphereCollider sphereCollider;
    public GameObject chunkManager;
    public List<MeshCollider> chunks;
    public List<MeshCollider> collidingChunks;
    public GameObject panel;
    public float distance;
    void Start()
    {

    }

    void Update()
    {
        ////if (chunks.Count == 0)
        ////{
        //    foreach (Transform child in chunkManager.transform)
        //    {
        //        if(!chunks.Contains(child.GetComponent<MeshCollider>()))
        //        {
        //            chunks.Add(child.GetComponent<MeshCollider>());
        //        }
        //    }
        ////}

        //foreach (MeshCollider chunk in chunks)
        //{
        //    if (Vector3.Distance(chunk.transform.position, sphereCollider.transform.position) < distance)
        //    {
        //        collidingChunks.Add(chunk);
        //    }
        //    else
        //    {
        //        if(collidingChunks.Contains(chunk))
        //        {
        //            collidingChunks.Remove(chunk);
        //        }
        //    }
        //}

        //foreach(MeshCollider chunk in collidingChunks)
        //{
        //    if (Vector3.Distance(chunk.transform.position, sphereCollider.transform.position) < distance)
        //    {
        //        camera.fieldOfView = 0;
        //    }
        //    else
        //    {
        //        if (camera.fieldOfView == 0)
        //        {
        //            camera.fieldOfView = 90;
        //        }
        //        if (collidingChunks.Contains(chunk))
        //        {
        //            collidingChunks.Remove(chunk);
        //        }
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            panel.SetActive(true);
            print("enter");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            panel.SetActive(false);
            print("exit");
        }
    }
}
