using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MarchingCubes;

public class FossilHolder : Singleton<FossilHolder>
{
    // FossilInfo(string _name, eDiet _diet, string _aliveLocation, string _generalInformation,
    //   string _lengthRange, string _timePeriod, string _weightRange)

    public static List<FossilInfo> fossilBits = new List<FossilInfo>() {
        new FossilInfo("Allosaurus", FossilInfo.eDiet.CARNIVORE, "USA, Portugal",
            "Ziphodont teeth (sword-toothed): Teeth are curved backwards, narrow from side to side and finely serrated. These are found in living predatory lizards and sharks and are indicators of a predatory lifestyle that involves the attacking and eating of animals. \n They used rapid, slashing bites to weaken and kill prey. \n",
            "8.5 meters / 28 feet long", "Late Jurassic", "over 1.5 tons"),
        new FossilInfo("Barosaurus", FossilInfo.eDiet.HERBIVORE, "USA, Tanzania",
            "Barosaurus means 'heavy lizard'",
            "24 meters / 78.7 feet long", "Late Jurassic", "over 20 tons"),
        new FossilInfo("Lobocarcinus", FossilInfo.eDiet.CARNIVORE, "New Zealand, Southern Pacific Ocean",
            "Lobocarcinus are in the family of sponge crabs.\n They relied on drag-powered swimming to move.",
            "91.6 millimeters / 3.6 inches long and 119.4 millimeters / 4.7 inches wide", "Eocene Epoch (Paleogene)", "around 1 pounds / 453.6 grams"),
        new FossilInfo("Parasaurolophus", FossilInfo.eDiet.HERBIVORE, "Canada, USA",
            "They are a hadrosaurid, part of a family of dinosaurs known for having unique head adornments.",
            "11 meters / 36.1 feet long", "Late Cretaceous", "3.9 tons"),
        new FossilInfo("Plesiosaurus", FossilInfo.eDiet.CARNIVORE, "European seas, Pacific Ocean",
            "Nostrils located far back on the head near the eyes.\n They swam by flapping their fins in the water, much like sea lions do today, in a modified style of underwater 'flight.'",
            "4.5 meters / 15 feet long", "Late Triassic - Late Cretaceous", "over 49 tons"),
        new FossilInfo("Pterodactyl", FossilInfo.eDiet.CARNIVORE,"Germany",
            "Juvenile pterodactyls were called flaplings.\n Pterodactyls were not dinosaurs. Dinosaurs are generally considered to walk upright, on either two legs or four legs. Pterodactyls often didn't walk at all, and when they did walk, they waddled on their back legs and pointed wings. Animals like them are called pterosaurs.",
            "1 meter / 3 feet wingspan", "Late Jurassic - Late Cretaceous", "40 kilograms / 88 pounds"),
        new FossilInfo("Trilobite", FossilInfo.eDiet.CARNIVORE, "Northern USA East Coast, Pacific Ocean",
            "They had three-part bodies.\n They could roll into balls for protection.\n First group of animals in the animal kingdom to develop complex eyes and multiple appendages for moving around.",
            "1 to over 70 centimeters long", "Early Cambrian Period", "up to 4.5 kilograms / 10 pounds"),
        new FossilInfo("Tyrannosaurus Rex", FossilInfo.eDiet.CARNIVORE, "USA, Canada",
            "Tyrannosaurus Rex means 'tyrant lizard.'\n Their powerful jaws had 60 teeth, each one up to 20 centimeters / 8 inches long, and their bite was around 3 times as powerful than that of a lion.\n They have close relatives that sometimes lived together because there are fossils of groups who were buried together, but we don't know for sure if they hunted alone, or in packs like lions and wolves do today.",
            "12 meters / 39.3 feet long", "Late Cretaceous", "over 7 tons"),
        new FossilInfo("Utahraptor", FossilInfo.eDiet.CARNIVORE, "Utah, USA",
            "They are closely related to birds.\n Prior to their discovery, paleontologists believed sickle-clawed dromaeosaurids were small carnivores that only lived in the Late Cretaceous. They required paleontologists to revise their understanding of this family of dinosaurs as it was much larger and lived the Early Cretaceous.",
            "6 meters / 19.7 feet long", "Early Cretaceous", "over a ton")
    };
    public static List<string> backpack = new List<string>(); 

    [SerializeField] static OVRGrabber grabber;

    private void Awake()
    {
        base.Awake();
        if (Instance == this)
        {
            DontDestroyOnLoad(this);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            backpack.Add("Utahraptor");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            backpack.Clear();
            fossilBits.ForEach(f => f.found = false);
            FindObjectOfType<GameManager>().LoadScene(0);
        }
    }

    public string[] backpackContents()
    {
        return backpack.ToArray();
    }

    public static void FossilFound(string n)
    {
        foreach(var f in fossilBits)
        {
            if(f.name == n)
            {
                f.found = true;
                backpack.Remove(n);
                break;
            }
        }
    }

    //adds unburied Fossil to backpack
    public static void AddToBackpack(string n)
    {
        if(!backpack.Contains(n)) backpack.Add(n);
    }

    //TODO: Not Used ???
    //brings fossil to hand, fails if -1 is returned, otherwise returns fossil index
    public int GrabFossil(Fossil fossil)
    {
        Fossil f;
        int fossilIndex = 0;
        if (fossil == null) return -1;
        //needs to clear hand of any fossils and put back in backpack
        Fossil grabbedFossil = new Fossil();
        for (int i = 0; i < backpack.Count - 1; i++)
        {
            /*f = backpack[i];
            if (f == fossil)
            { 
                grabbedFossil = f;
                backpack.Remove(f);
                fossilIndex = i;
                break;
            }*/
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

    public bool IsFound(string name)
    {
        foreach(var i in fossilBits)
        {
            if (i.name == name) return i.found;
        }
        return false;
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
    public string aliveLocation;
    public string generalInformation;
    public string lengthRange;
    public string timePeriod;
    public string weightRange;


    public FossilInfo(string _name, eDiet _diet, string _aliveLocation, string _generalInformation, 
        string _lengthRange, string _timePeriod, string _weightRange)
    {
        found = false;
        name = _name;
        diet = _diet;
        aliveLocation = _aliveLocation;
        generalInformation = _generalInformation;
        lengthRange = _lengthRange;
        timePeriod = _timePeriod;
        weightRange = _weightRange;
    }
}