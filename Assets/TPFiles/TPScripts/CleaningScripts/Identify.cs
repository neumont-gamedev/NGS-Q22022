using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Identify : MonoBehaviour
{

    public TMP_Text uAnswer;
    public TMP_Text rAnswer;
    public TMP_Text uMarkings;
    public TMP_Text uHappened;
    public TMP_Text uPart;
    public TMP_Text uCreature;

    public IdentifyData curData;

 
    public void CheckQuestion()
    {

        curData = FindObjectOfType<IdentifyData>();

        if(curData.Creature_Name.ToString() == "Trilobite")
        {
            uAnswer.text = "The fossil is the " + uPart + "of a " + uCreature;
        }
        else
        {
            uAnswer.text = "The fossil is the " + uPart + "of a " + uCreature + " it has " + uMarkings + " marks. This creature " + uHappened;
        }
      

        rAnswer.text = curData.FinalAnswer;

    }
}
