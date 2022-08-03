using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseumManager : MonoBehaviour
{
    public GameObject[] displays;

    private void Start()
    {
        SpawnDisplay();
    }
    public void SpawnDisplay()
    {
        //Activates found fossils
        FossilHolder holder = FindObjectOfType<FossilHolder>();
        foreach(var d in displays)
        {
            Debug.Log("Display:" + d.name + ":" + holder.IsFound(d.name).ToString());
            d.SetActive(holder.IsFound(d.name));
        }
    }
}
