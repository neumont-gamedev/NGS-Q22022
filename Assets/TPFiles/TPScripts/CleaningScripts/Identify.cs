using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Identify : MonoBehaviour
{
    public TMP_Text userAnswer;
    public string rAnswer;
    
    public string userMarkings;
    public TMP_Text fMarkings;
    public string userPart;
    public TMP_Text fPart;
    public string userCreature;
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
            userPart = answer;
            fPart.text = answer;
        }
        else if(answer == "Scratch" || answer == "Holes" || answer == "Bug Bites" || answer == "Fractures")
        {
            userMarkings = answer;
            fMarkings.text = answer;
        }
        else if(answer == "Allosaurus" || answer == "Barosaurus" || answer == "Iguanadon" || answer == "Pterodactyl" || answer == "Trilobite" || answer == "Plesiosaurus" || answer == "Trex" || answer == "UtahRaptor")
        {
            userCreature = answer;
            fCreature.text = answer;
        }

    }

    public void CheckQuestion()
    {
        if(curData.boneData.Creature_Name.ToString() == "Trilobite")
        {
            userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature;
        }
        else
        {
            userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
        }  

        //rAnswer.text = curData.boneData.FinalAnswer;
        resultsPage.SetActive(true);
    }
}
