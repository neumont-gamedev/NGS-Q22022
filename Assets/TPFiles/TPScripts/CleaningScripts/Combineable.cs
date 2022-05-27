using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Combineable : MonoBehaviour
{
    public List<GameObject> boneParts = new List<GameObject>();
    public int combinedBoneCounter = -1;

    private bool isClean = false;
    private List<OVRGrabber> hands = new List<OVRGrabber>();

    void Start()
    {
        //Get hands OVRGrabbers
        GameObject[] temp = GameObject.FindGameObjectsWithTag("Hand");
        for(int i = 0; i < temp.Length; i++) 
        { 
            if (temp[i].GetComponent<OVRGrabber>() != null) hands.Add(temp[i].GetComponent<OVRGrabber>());
        }
    }

    public void Clean() { isClean = true; }

    public int GetBoneCounter()
    {
        return combinedBoneCounter;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (isClean) { 
            if (collidedObject.tag == "BottomColliderRight" || collidedObject.tag == "BottomColliderLeft")
            {
                for (int i = 0; i < boneParts.Count; i++)
                {
                    if (collidedObject.transform.parent.name.Equals(boneParts[i].gameObject.name))
                    {
                        this.boneParts[i].SetActive(true);
                        combinedBoneCounter += 1;

                        //Force release of object before destroying it
                        foreach (var h in hands) h.ForceRelease(other.gameObject.GetComponent<OVRGrabbable>());

                        Destroy(collidedObject.transform.parent.gameObject);
                    }
                }
            }
        }
    }
}
