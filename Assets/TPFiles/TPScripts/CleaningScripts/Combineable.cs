using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Combineable : MonoBehaviour
{
    public List<GameObject> boneParts = new List<GameObject>();
    [SerializeField] int combinedBoneCounter = -1;

    private bool isClean = false;

    public void Clean() { isClean = true; }

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
                        c.m_grabbedBy.ForceRelease(c);

                        Destroy(collidedObject.transform.parent.gameObject);
                        return;
                    }
                }
            }
        }
    }
}
