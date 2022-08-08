using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabManager : MonoBehaviour
{
    public GameManager gManager;
    //public AirScribe airScribe;
    public ObjectEnabler objectEnabler;
    public GameObject museumPlayerSpawn;
    public GameObject labPlayerSpawn;
    public GameObject player;
    public SpawnFossil fossilSpawner;
    public MuseumManager museumManager;
    public NewClean airScribe;

    public void EnterLabClick()
    {
        if (LoadLab())
        {

            //transport
            //spawn player
            player.SetActive(false);
            player.transform.position = labPlayerSpawn.transform.position;
            player.SetActive(true);
            objectEnabler.inLab = true;
            fossilSpawner.FossilSpawn();
            airScribe.StartCleanProcess();
        }

    }

    public void ExitLabClick()
    {
        foreach (GameObject fossil in fossilSpawner.activeFossils)
        {
            Destroy(fossil);
        }

        //museumManager.SpawnDisplay();
        airScribe.EndClean();
        objectEnabler.inLab = false;
        gManager.LoadScene(0);
        player.SetActive(false);
        player.transform.position = museumPlayerSpawn.transform.position;
        player.SetActive(true);
    }


    public GameObject LabButton;
    public GameObject NoFossilsText;

    //checks to see if player can enter lab
    //based on if they have any fossils to clean
    public bool LoadLab()
    {
        //If player doesnt have a fossil
        // Deactivate Lab Button
        if (FossilHolder.Instance.backpack.Count == 0)
        {

            LabButton.SetActive(false);
            NoFossilsText.SetActive(true);
            return false;
        }
        else
        {
            //Reactiveate Button if Button is disabled
            if (!LabButton.activeSelf)
            {
                LabButton.SetActive(true);
                NoFossilsText.SetActive(false);

            }

            return true;
        }
    }
}
