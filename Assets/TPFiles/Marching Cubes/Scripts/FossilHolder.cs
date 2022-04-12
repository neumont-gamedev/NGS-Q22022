using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes;

public class FossilHolder : Singleton<FossilHolder>
{
    public static List<FossilInfo> fossilBits = new List<FossilInfo>() { 
        new FossilInfo("test01"), new FossilInfo("test02") };

    private void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(this);
        }
    }

    public static void UpdateFossil(GameObject fossil)
    {
        foreach(var f in fossilBits)
        {
            if(f.name == fossil.GetComponent<Fossil>().name)
            {
                f.location = fossil.transform.position;
                f.found = fossil.GetComponent<Fossil>().wasFound;
                Debug.Log(f.found);
                continue;
            }
        }
    }
}


public class FossilInfo
{
    public bool found;
    public string name;
    public Vector3 location;

    public FossilInfo(string n)
    {
        found = false;
        name = n;
    }
}