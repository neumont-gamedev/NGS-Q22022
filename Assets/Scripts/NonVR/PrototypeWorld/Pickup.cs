using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using TMPro;

public class Pickup : MonoBehaviour
{
    public BoneData boneData;

    public OVRPlayerController curPlayer;

    InfoManager info;

    Collision currentcollision;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collide)
    {
        if (collide.tag == "Player")
        {
            collide.GetComponentInChildren<InfoManager>().GetInfo(boneData.name, boneData.CreatureName, boneData.CreatureFact);
        }
        //Debug.Log("Entered");
    }

    private void DestroyMaterial()
    {
        if (currentcollision.collider.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        else
        {
            //Debug.Log(health);
        }
    }
}

