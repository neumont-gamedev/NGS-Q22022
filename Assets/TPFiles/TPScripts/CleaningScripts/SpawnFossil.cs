using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFossil : MonoBehaviour
{
    public GameObject[] fossils;
    public string[] fossilNames;
    public GameObject spawnPoint;

    private FossilHolder holder;

    void Start()
    {
        holder = GetComponent<FossilHolder>();
        for(int i = 0; i < fossilNames.Length; i++)
        {
            if(fossilNames[i] == holder.backpackContents()[0])
            {
                Instantiate(fossils[i], spawnPoint.transform);
            }
        }
    }
}
