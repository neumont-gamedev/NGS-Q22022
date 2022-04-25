using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combineable : MonoBehaviour
{
    Collider[] childColliders;

    Collider leftCollider;
    Collider rightCollider;

    public GameObject combinePoint;
    public string combinableWantedObject;

    public List<GameObject> boneParts = new List<GameObject>();

 /*   public GameObject hiddenJaw;
    public GameObject hiddenNose;
    public GameObject hiddenHead;*/

    GameObject parentObject = new GameObject();

    void Start()
    {
        childColliders = GetComponentsInChildren<BoxCollider>();

        leftCollider = (childColliders[0].tag == "BottomColliderLeft") ? childColliders[0] : childColliders[1];
        rightCollider = (childColliders[0].tag == "BottomColliderLeft") ? childColliders[1] : childColliders[0];
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (rightCollider.gameObject.tag == collidedObject.tag)
        {
            for (int i = 0; i < boneParts.Count; i++)
            {
                Debug.Log(collidedObject.transform.parent.name);
                Debug.Log(boneParts[i].gameObject.name);
                if (collidedObject.transform.parent.name.Equals(boneParts[i].gameObject.name))
                {
                    this.boneParts[i].SetActive(true);
                    Destroy(collidedObject.transform.parent.gameObject);
                    Debug.Log("I CHOOSE YOU " + boneParts[i].gameObject.name);
                }
            }
        }
    }
}
