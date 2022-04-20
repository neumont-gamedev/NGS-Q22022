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

    public GameObject hiddenJaw;
    public GameObject hiddenNose;

    GameObject parentObject = new GameObject();

    void Start()
    {
        childColliders = GetComponentsInChildren<BoxCollider>();

        leftCollider = (childColliders[0].tag == "BottomColliderLeft") ? childColliders[0] : childColliders[1];
        rightCollider = (childColliders[0].tag == "BottomColliderLeft") ? childColliders[1] : childColliders[0];
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (rightCollider.gameObject.tag == collidedObject.tag)
        {
            if (hiddenJaw.transform.root.gameObject.name == collidedObject.transform.root.gameObject.name)
            {
                hiddenJaw.SetActive(true);
                Destroy(this.gameObject);
            }
            else if (hiddenNose.transform.root.gameObject.name == collidedObject.transform.root.gameObject.name)
            {
                hiddenNose.SetActive(true);
                Destroy(this.gameObject);
            }
            transform.SetParent(collidedObject.transform);
            //combinePoint.transform.position = GameObject.Find(combinableWantedObject).transform.position;
            Debug.Log(rightCollider.gameObject.name + " Collided with " + collidedObject.name);
        }
        else if (leftCollider.gameObject.tag == other.gameObject.tag)
        {
            transform.SetParent(collidedObject.transform);
            //combinePoint.transform.position = GameObject.Find(combinableWantedObject).transform.position;
            Debug.Log(leftCollider.gameObject.name + " Collided with " + collidedObject.name);
        }
    }
}
