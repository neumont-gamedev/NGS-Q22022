using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabManager : MonoBehaviour
{

    public AirScribe airScribe;
    public ObjectEnabler objectEnabler;
    public GameObject museumPlayerSpawn;
    public GameObject labPlayerSpawn;
    public GameObject player;
    public SpawnFossil fossilSpawner;
    public MuseumManager museumManager;

    public void EnterLabClick()
    {
        if (LoadLab())
        {
            //transport
            //spawn player
            fossilSpawner.FossilSpawn();
            player.SetActive(false);
            player.transform.position = labPlayerSpawn.transform.position;
            player.SetActive(true);
            airScribe.StartClean();
            objectEnabler.inLab = true;
        }

    }

    public void ExitLabClick()
    {
        foreach (GameObject fossil in fossilSpawner.activeFossils)
        {
            Destroy(fossil);
        }

        museumManager.SpawnDisplay();
        airScribe.EndClean();
        player.SetActive(false);
        player.transform.position = museumPlayerSpawn.transform.position;
        player.SetActive(true);
        objectEnabler.inLab = false;
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
