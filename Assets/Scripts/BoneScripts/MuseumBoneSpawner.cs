using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumBoneSpawner : MonoBehaviour
{
    public GameObject boneToSpawn;
    public GameObject spawnLocation;
    void Start()
    {
        if(PickedUpData.megalodon1)
        {
            Instantiate(boneToSpawn,spawnLocation.transform.position,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
