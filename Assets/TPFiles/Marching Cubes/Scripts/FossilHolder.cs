using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes;

public class FossilHolder : Singleton<FossilHolder>
{
    public static List<FossilInfo> fossilBits = new List<FossilInfo>() {
        new FossilInfo("test01"), new FossilInfo("test02") };
    public static List<Fossil> backpack = new List<Fossil>();
    [SerializeField] static OVRGrabber grabber;

    private void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(this);
        }
    }

    //updates the fossil location
    public static void UpdateFossil(GameObject fossil)
    {
        foreach (var f in fossilBits)
        {
            if (f.name == fossil.GetComponent<Fossil>().name)
            {
                f.location = fossil.transform.position;
                continue;
            }
        }
    }

    //updates the fossil found 
    public static void FossilFound(Fossil fossil)
    {
        foreach (var f in fossilBits)
        {
            if (f.name == fossil.name)
            {
                f.found = fossil.wasFound;
                Debug.Log(f.found);
                continue;
            }
        }
    }

    //adds Fossil to backpack
    public static void AddToBackpack(Fossil fossil)
    {
        if (grabber.grabbedObject != null)
        {
            backpack.Add(fossil);
            grabber.ForceRelease(grabber.grabbedObject);
        }
    }

    //brings fossil to hand, fails if -1 is returned, otherwise returns fossil index
    public int GrabFossil(Fossil fossil)
    {
        int fossilIndex = 0;
        if (fossil == null) return -1;
        //needs to clear hand of any fossils and put back in backpack
        Fossil grabbedFossil = new Fossil();
        foreach (Fossil f in backpack)
        {
            if (f == fossil)
            { 
                grabbedFossil = f;
                backpack.Remove(f);
                break;
            }

            fossilIndex++;
        }

        if (grabbedFossil == null)
        {
            print("no bones for you");
        }
        else
        {
            grabber.ForceRelease(grabber.grabbedObject);
            Fossil backpackFossil = Instantiate(fossil, grabber.transform);
            // <-- check if fossilFromBackpack has OVRGrabbable -->
            if(backpackFossil.TryGetComponent<OVRGrabbable>(out OVRGrabbable grabFossil))
            {
                grabber.grabbedObject = grabFossil;
                return fossilIndex;
            }
        }

        return -1;
    }
}

public class FossilInfo
{
    public enum eDiet{
        CARNIVORE, 
        HERBIVORE,
        OMNIVORE
    }

    public bool found;
    public string name;
    public Vector3 location;
    public Sprite inventorySprite;
    public GameObject fossilPrefab;

    public eDiet diet;
    public string generalInformation;
    public string lengthRange;
    public string timePeriod;
    public string weightRange;


    public FossilInfo(string n)
    {
        found = false;
        name = n;
    }
}