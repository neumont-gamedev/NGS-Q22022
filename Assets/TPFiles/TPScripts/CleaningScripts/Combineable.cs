using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Combineable : MonoBehaviour
{
    Collider[] childColliders;

    Collider leftCollider;
    Collider rightCollider;

    public List<GameObject> boneParts = new List<GameObject>();

    public int combinedBoneCounter = -1;

    void Start()
    {
        childColliders = GetComponentsInChildren<BoxCollider>();

        leftCollider = (childColliders[0].tag == "BottomColliderLeft") ? childColliders[0] : childColliders[1];
        rightCollider = (childColliders[0].tag == "BottomColliderLeft") ? childColliders[1] : childColliders[0];
    }


    public int GetBoneCounter()
    {
        return combinedBoneCounter;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (rightCollider.gameObject.tag == collidedObject.tag || leftCollider.gameObject.tag == collidedObject.tag)
        {
            for (int i = 0; i < boneParts.Count; i++)
            {
                Debug.Log(collidedObject.transform.parent.name);
                Debug.Log(boneParts[i].gameObject.name);
                if (collidedObject.transform.parent.name.Equals(boneParts[i].gameObject.name))
                {
                    this.boneParts[i].SetActive(true);
                    combinedBoneCounter += 1;
                    //gameObject.GetComponent<OVRGrabber>().colliders.Clear();
                    Destroy(collidedObject.transform.parent.gameObject);
                    Debug.Log("I CHOOSE YOU " + boneParts[i].gameObject.name);
                }
                Debug.Log("Bone Couner Count From Active OBJ : " + combinedBoneCounter);
            }
        }
    }
}
