using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFossil : MonoBehaviour
{
    public GameObject[] fossils;
    public string[] fossilNames;
    public GameObject spawnPoint;

    private FossilHolder holder;

    //Should be used in lab scene
    //Spawns first fossil in the backpack
    void Start()
    {
        holder = FindObjectOfType<FossilHolder>();
        for(int i = 0; i < fossilNames.Length; i++)
        {
            if(fossilNames[i] == holder.firstFossil())
            {
                Instantiate(fossils[i], spawnPoint.transform);
                fossils[i].gameObject.SetActive(true);
                return; 
            }
        }
    }
}
