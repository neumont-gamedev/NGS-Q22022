using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Identify : MonoBehaviour
{
    public TMP_Text uAnswer;
    public string rAnswer;
    
    public string uMarkings;
    public TMP_Text fMarkings;
    public string uPart;
    public TMP_Text fPart;
    public string uCreature;
    public TMP_Text fCreature;


    public DataHolder curData;

    public GameObject resultsPage;

    private void Start()
    {
        curData = FindObjectOfType<DataHolder>();
    }

    public void InsertAnswer(string answer)
    {
        if(answer == "Head" || answer == "Tail" || answer == "Foot" || answer == "Pelvis")
        {
            uPart = answer;
            fPart.text = answer;
        }
        else if(answer == "Scratch" || answer == "Holes" || answer == "Bug Bites" || answer == "Fractures")
        {
            uMarkings = answer;
            fMarkings.text = answer;
        }
        else if(answer == "Allosaurus" || answer == "Barosaurus" || answer == "Iguanadon" || answer == "Pterodactyl" || answer == "Trilobite" || answer == "Plesiosaurus" || answer == "Trex" || answer == "UtahRaptor")
        {
            uCreature = answer;
            fCreature.text = answer;
        }

    }

    public void CheckQuestion()
    {
        if(curData.boneData.Creature_Name.ToString() == "Trilobite")
        {
            uAnswer.text = "The fossil is the " + uPart + "of a " + uCreature;
        }
        else
        {
            uAnswer.text = "The fossil is the " + uPart + "of a " + uCreature + " it has " + uMarkings + " marks.";
        }  

        //rAnswer.text = curData.boneData.FinalAnswer;
        resultsPage.SetActive(true);
    }
}
