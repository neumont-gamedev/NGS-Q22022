using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes;

public class FossilHolder : Singleton<FossilHolder>
{
    public static List<FossilInfo> fossilBits = new List<FossilInfo>() { 
        new FossilInfo("SampleFossil"), new FossilInfo("SampleFossil 1") };
    public static List<Fossil> backpack = new List<Fossil>();

    private void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(this);
        }
    }

    //updates the fossil found 
    public static void FossilFound(Fossil fossil)
    {
        foreach (var f in fossilBits)
        {
            if (f.name == fossil.name)
            {
                f.found = fossil.isFound();
                //Debug.Log(f.found);
                continue;
            }
        }
    }

    //adds Fossil to backpack
    public static void AddToBackpack(Fossil fossil)
    {
        backpack.Add(fossil);
    }
}


public class FossilInfo
{
    public bool found;
    public string name;

    public FossilInfo(string n)
    {
        found = false;
        name = n;
    }
}