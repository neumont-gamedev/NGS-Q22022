using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonePickUp : MonoBehaviour
{
    public AudioSource pickUpNoise;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bone")
        {
            switch(other.name)
            {
                case "Megalodon 1":
                    Debug.Log(PickedUpData.megalodon1);
                    PickedUpData.megalodon1 = true;
                    Debug.Log(PickedUpData.megalodon1);
                    Debug.Log("Picked up megalodon1");
                    break;
                case "Megalodon 2":
                    PickedUpData.megalodon2 = true;
                    break;
                case "Megalodon 3":
                    PickedUpData.megalodon3 = true;
                    break;
                case "Triceratops 1":
                    PickedUpData.triceratops1 = true;
                    break;
                case "Triceratops 2":
                    PickedUpData.triceratops2 = true;
                    break;
                case "Triceratops 3":
                    PickedUpData.triceratops3 = true;
                    break;
                case "Velociraptor 1":
                    PickedUpData.velociraptor1 = true;
                    break;
                case "Velociraptor 2":
                    PickedUpData.velociraptor2 = true;
                    break;
                case "Velociraptor 3":
                    PickedUpData.velociraptor3 = true;
                    break;
            }
           
            Destroy(other.gameObject, 3);
            pickUpNoise.Play();
            Debug.Log("Store Bone");
        }
        else
        {
            Debug.Log("Not a Bone");
        }
    }


}
