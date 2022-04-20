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

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedObject = other.gameObject;

        if (rightCollider.gameObject.tag == collidedObject.tag)
        {
            for(int i = 0; i <= boneParts.Count; i++)
            {
                if (collidedObject.name.Equals(boneParts[i].gameObject.name))
                {
                    Debug.Log(collidedObject.name);
                    Debug.Log(boneParts[i].gameObject.name);
                    this.boneParts[i].SetActive(true);
                    Debug.Log("I CHOOSE YOU " + boneParts[i].gameObject.name);
                }
                Debug.Log("None Found");
            }


            //Debug.Log()


            /* if (hiddenJaw.transform.root.gameObject.name == collidedObject.transform.root.gameObject.name)
             {
                 hiddenJaw.SetActive(true);
                 Destroy(this.gameObject);
             }
             else if (hiddenNose.transform.root.gameObject.name == collidedObject.transform.root.gameObject.name)
             {
                 hiddenNose.SetActive(true);
                 Destroy(this.gameObject);
             }*/
            //transform.SetParent(collidedObject.transform);
            //combinePoint.transform.position = GameObject.Find(combinableWantedObject).transform.position;
            //boneParts[0].SetActive(true);
            Debug.Log(rightCollider.gameObject.name + " Collided with " + collidedObject.name);
        }
        else if (leftCollider.gameObject.tag == other.gameObject.tag)
        {
            //transform.SetParent(collidedObject.transform);
            //combinePoint.transform.position = GameObject.Find(combinableWantedObject).transform.position;
            Debug.Log(leftCollider.gameObject.name + " Collided with " + collidedObject.name);
        }
    }
}
