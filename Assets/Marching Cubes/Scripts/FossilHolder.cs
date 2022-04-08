using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilHolder : MonoBehaviour
{
    private static FossilHolder instance;
    public List<FossilInfo> fossilBits = new List<FossilInfo>() { 
        new FossilInfo("test01"), new FossilInfo("test02") };

    private void Awake()
    {
        //TODO test this
    /*if(instance == null)
    {
        instance = this;
        DontDestroyOnLoad(this);
    }*/
    }

    public void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
            Destroy(gameObject);
        }
    }

    public static bool IsCreated()
    {
        return (instance != null);
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