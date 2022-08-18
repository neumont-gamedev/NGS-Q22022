using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class JournalIdentify : MonoBehaviour
{
    public TMP_Text userAnswer;
    public string rAnswer;

    public string userMarkings;
    public TMP_Text fMarkings;
    public string userPart;
    public TMP_Text fPart;
    public string userCreature;
    public TMP_Text fCreature;
    public List<GameObject> m_Plaques;

    private Sprite chosenPart;
    private Sprite chosenMarking;
    private Sprite chosenCreature;

    public string currentDino;
    public List<DataHolder> m_Data;

    public GameObject resultsPage;

    private void Start()
    {
        
    }

    public void FillAnswers()
    {
        fPart.text = userPart;
        fMarkings.text = userMarkings;
        fCreature.text = userCreature;
    }

    public void InsertAnswer(string answer)
    {
        //needed specific functionality with the icons for the plaques
        switch (answer)
        {
            case "Head":
                userPart = answer;
                break;
            case "Tail":
                userPart = answer;
                break;
            case "Foot":
                userPart = answer;
                break;
            case "Pelvis":
                userPart = answer;
                break;
            case "Scratch":
                userMarkings = answer;
                break;
            case "Holes":
                userMarkings = answer;
                break;
            case "Bug Bites":
                userMarkings = answer;
                break;
            case "Fractures":
                userMarkings = answer;
                break;
            case "Allosaurus":
                userCreature = answer;
                break;
            case "Trilobite":
                userCreature = answer;
                break;
            case "Trex":
                userCreature = answer;
                break;
            case "UtahRaptor":
                userCreature = answer;
                break;
            case "Triceratops":
                userCreature = answer;
                break;
            default:
                break;
        }
        /*if (answer == "Head" || answer == "Tail" || answer == "Foot" || answer == "Pelvis")
        {
            userPart = answer;
        }
        else if (answer == "Scratch" || answer == "Holes" || answer == "Bug Bites" || answer == "Fractures")
        {
            userMarkings = answer;
        }
        else if (answer == "Allosaurus" || answer == "Barosaurus" || answer == "Iguanadon" || answer == "Pterodactyl" || answer == "Trilobite" || answer == "Plesiosaurus" || answer == "Trex" || answer == "UtahRaptor")
        {
            userCreature = answer;
        }*/

    }

    public void CheckQuestion()
    {
        resultsPage.SetActive(true);
        switch (currentDino)
        {
            case "Allosaurus_Pelvis":
            case "Allosaurus_Skull":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdateAnswers(0);
                UpdatePlaques();
                break;
            case "Trilobite_Final":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdateAnswers(1);
                UpdatePlaques();
                break;
            case "TyrannosaurusRex_Foot":
            case "TyrannosaurusRex_Pelvis":
            case "TyrannosaurusRex_Skull":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdateAnswers(2);
                UpdatePlaques();
                break;
            case "Utahraptor_Pelvis":
            case "Utahraptor_Tail":
            case "Utahraptor_Head":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdateAnswers(3);
                UpdatePlaques();
                break;
            case "Triceratops_Pelvis":
            case "Triceratops_Head":
            case "Triceratops_Foot":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdateAnswers(4);
                UpdatePlaques();
                break;
            default:
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature;
                UpdateAnswers(0);
                UpdatePlaques();
                break;
        }

    }

    public void UpdatePlaques()
    {
        foreach(GameObject plaque in m_Plaques)
        {
            plaque.SetActive(false);
        }
    }

    public void UpdateAnswers(int plaque)
    {
        m_Data[plaque].boneData.Markings = userMarkings;
        m_Data[plaque].boneData.Body_Part = userPart;
        m_Data[plaque].boneData.Creature_Name = userCreature;
    }

    public void CleanAnswers()
    {
        userMarkings = "default";
        userPart = "default";
        userCreature = "default";
        int counter = 0;
        foreach(DataHolder holder in m_Data)
        {
            UpdateAnswers(counter);
            counter++;
        }
    }
}