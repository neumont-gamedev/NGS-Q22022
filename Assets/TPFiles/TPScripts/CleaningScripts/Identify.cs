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

    public DataHolder curData;

    public GameObject resultsPage;

    private void Start()
    {
        curData = FindObjectOfType<DataHolder>();
    }

    public void CheckQuestion()
    {
        if(curData.boneData.Creature_Name.ToString() == "Trilobite")
        {
            uAnswer.text = "The fossil is the " + uPart.text + "of a " + uCreature.text;
        }
        else
        {
            uAnswer.text = "The fossil is the " + uPart.text + "of a " + uCreature.text + " it has " + uMarkings.text + " marks. This creature " + uHappened.text;
        }
      

        rAnswer.text = curData.boneData.FinalAnswer;
        resultsPage.SetActive(true);


    }
}
