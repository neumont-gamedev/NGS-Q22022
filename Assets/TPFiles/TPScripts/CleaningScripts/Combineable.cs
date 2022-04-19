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

    GameObject parentObject = new GameObject();

    void Start()
    {
        childColliders = GetComponentsInChildren<BoxCollider>();

        if (childColliders[0].tag == "BottomColliderLeft" && childColliders[1].tag == "BottomColliderRight")
        {
            leftCollider = childColliders[0];
            rightCollider = childColliders[1];
        }
        else
        {
            leftCollider = childColliders[1];
            rightCollider = childColliders[0];
        }

        Debug.Log("Left Collider : " + leftCollider.tag);
        Debug.Log("Right Collider : " + rightCollider.tag);
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (rightCollider.gameObject.tag == other.gameObject.tag)
        {
            //transform.SetParent(parentObject.transform);
            combinePoint.transform.position = GameObject.Find(combinableWantedObject).transform.position;
            Debug.Log("Collided Right");
        }
        if (leftCollider.gameObject.tag == other.gameObject.tag)
        {
            //transform.SetParent(parentObject.transform);
            combinePoint.transform.position = GameObject.Find(combinableWantedObject).transform.position;
            Debug.Log("Collided Left");
        }
    }
}
