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
    public List<TMP_Text> plaqueList;
    public List<UnityEngine.UI.Image> plaqueImageList;
    public List<Sprite> partList;
    public List<Sprite> markingList;
    public List<Sprite> creatureList;

    private Sprite chosenPart;
    private Sprite chosenMarking;
    private Sprite chosenCreature;

    public string currentDino;

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
                chosenPart = partList[0];
                break;
            case "Tail":
                userPart = answer;
                chosenPart = partList[1];
                break;
            case "Foot":
                userPart = answer;
                chosenPart = partList[2];
                break;
            case "Pelvis":
                userPart = answer;
                chosenPart = partList[3];
                break;
            case "Scratch":
                userMarkings = answer;
                chosenMarking = markingList[0];
                break;
            case "Holes":
                userMarkings = answer;
                chosenMarking = markingList[1];
                break;
            case "Bug Bites":
                userMarkings = answer;
                chosenMarking = markingList[2];
                break;
            case "Fractures":
                userMarkings = answer;
                chosenMarking = markingList[3];
                break;
            case "Allosaurus":
                userCreature = answer;
                chosenCreature = creatureList[0];
                break;
            case "Trilobite":
                userCreature = answer;
                chosenCreature = creatureList[1];
                break;
            case "Trex":
                userCreature = answer;
                chosenCreature = creatureList[2];
                break;
            case "UtahRaptor":
                userCreature = answer;
                chosenCreature = creatureList[3];
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
            //Allosaurus Starts at 0
            case "Allosaurus_Pelvis":
            case "Allosaurus_Skull":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdatePlaque(0);
                break;
            //Trilobite Starts at 3
            case "Trilobite_Final":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdatePlaque(3);
                break;
            //Trex Starts at 6
            case "TyrannosaurusRex_Foot":
            case "TyrannosaurusRex_Pelvis":
            case "TyrannosaurusRex_Skull":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdatePlaque(6);
                break;
            //UtahRaptor Starts at 9
            case "Utahraptor_Pelvis":
            case "Utahraptor_Head":
            case "Utahraptor_Skull":
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
                UpdatePlaque(9);
                break;
            //Default overwrites Allosaurus Currently
            default:
                userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature;
                UpdatePlaque(0);
                break;
        }


        /*if (curData.boneData.Creature_Name.ToString() == "Trilobite")
        {
            userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature;
        }
        else if (curData.boneData.Creature_Name.ToString() == "Trilobite")
        {
            userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature;
        }
        else if (curData.boneData.Creature_Name.ToString() == "Trilobite")
        {
            userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature;
        }
        else if(curData.boneData.Creature_Name.ToString() == "Trilobite")
        {
            userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature;
        }
        else
        {
            userAnswer.text = "The fossil is the " + userPart + "of a " + userCreature + " it has " + userMarkings + " marks.";
        }*/
    }

    public void UpdatePlaque(int plaqueNumber)
    {
        //the problem is that we need to update multiple TMP_Text's in this function,
        //so I will make the input the modifier of this function rather than a reference to a specific Dino

        Debug.Log("Attempted to Update Plaques " + plaqueNumber + " through " + (plaqueNumber + 2));
        plaqueList[plaqueNumber].text = userPart;
        plaqueList[plaqueNumber + 1].text = userMarkings;
        plaqueList[plaqueNumber + 2].text = userCreature;
        plaqueImageList[plaqueNumber].sprite = chosenPart;
        plaqueImageList[plaqueNumber + 1].sprite = chosenMarking;
        plaqueImageList[plaqueNumber + 2].sprite = chosenCreature;
    }
}