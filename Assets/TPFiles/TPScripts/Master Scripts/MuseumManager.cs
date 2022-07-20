using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumManager : MonoBehaviour
{
    public GameObject[] displays;

    public void SpawnDisplay()
    {
        //Activates found fossils
        FossilHolder holder = FindObjectOfType<FossilHolder>();
        foreach(var d in displays)
        {
            d.SetActive(holder.IsFound(d.name));
        }
    }
}
