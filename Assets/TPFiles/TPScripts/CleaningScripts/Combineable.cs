using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Combineable : MonoBehaviour
{

    public List<GameObject> boneParts = new List<GameObject>();


    [SerializeField] public int combinedBoneCounter = -1;
    [SerializeField] public int cleanedCounter = 0;
    [SerializeField] public int polishCounter = 0;

    public List<MeshCollider> grabMeshes = new List<MeshCollider>();
    public List<OVRGrabbable> grabberFiles = new List<OVRGrabbable>(); 
    private bool isClean = false;

    private void Start()
    {
        foreach(MeshCollider coll in grabMeshes) { coll.enabled = false; }
        foreach (OVRGrabbable goll in grabberFiles) { goll.enabled = false; }
    }

    public void Clean() 
    { 
        isClean = true;
        foreach (OVRGrabbable goll in grabberFiles) { goll.enabled = true; }
    }

    public bool GetBoneCounter() { return combinedBoneCounter == boneParts.Count; }


    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (isClean) 
        { 
            if (collidedObject.tag == "BottomColliderRight" || collidedObject.tag == "BottomColliderLeft")
            {
                foreach(var a in boneParts)
                {
                    if (collidedObject.transform.parent.name.Equals(a.gameObject.name))
                    {
                        a.SetActive(true);
                        combinedBoneCounter++;

                        //Force release of object before destroying it
                        var c = collidedObject.gameObject.GetComponent<OVRGrabbable>();
                        Debug.Log(c);
                        if(c != null) c?.m_grabbedBy.ForceRelease(c);

                        Destroy(collidedObject.transform.parent.gameObject);
                        return;
                    }
                }
            }
        }
    }
}
