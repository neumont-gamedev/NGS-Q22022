using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MuseumData : MonoBehaviour
{
    public TextMeshProUGUI txtBoi;
    public IdentifyData DinoData;

    private void Start()
    {
        txtBoi.text = DinoData.FinalAnswer;
    }
}
