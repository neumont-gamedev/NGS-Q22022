using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataHolder : MonoBehaviour
{
    public IdentifyData boneData;

    public TMP_Text RightAnswersText;

    void Start()
    {
        RightAnswersText.text = boneData.FinalAnswer;
    }

    void Update()
    {
        
    }
}
