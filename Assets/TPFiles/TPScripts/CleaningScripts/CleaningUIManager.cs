using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CleaningUIManager : MonoBehaviour
{
    //public TMP_Text txtScribeSteps;
    public Toggle RockBreaktoggle;
    public Toggle Cleantoggle;
    public Text cToggleText;

    public Toggle Combinetoggle;
    public Toggle Polishtoggle;
    public Text polishToggleText;
    public Toggle Identifytoggle;

    public GameObject putTogetherDisplay;
    public AudioSource successAudio;
    public AudioClip[] clips;

    private void Start()
    {
        //txtScribeSteps.text = "Hold left trigger to free the fossil with the air scribe!";
    }

    public void CUIMCheckReset()
    {
        RockBreakToggleOff();
        CleanToggleOff();
        CombineToggleOff();
        PolishToggleOff();
        IdentifyToggleOff();
    }


    public void RockBreakToggleOn()
    {

        RockBreaktoggle.isOn = true;
        
        //txtScribeSteps.text = "Hold left trigger to clean the fossil!";
    }

    public void RockBreakToggleOff()
    {

        RockBreaktoggle.isOn = false;

        //txtScribeSteps.text = "Hold left trigger to clean the fossil!";
    }



    public void CleanToggleOn()
    {
        Cleantoggle.isOn = true;

        //txtScribeSteps.text = "Put the fossil back together!";
    }

    public void CleanToggleOff()
    {
        Cleantoggle.isOn = false;

        //txtScribeSteps.text = "Put the fossil back together!";
    }

    public void CleanToggleTextChange(int cleanedBones, int maxBones)
    {
        cToggleText.text = "Clean Bones. Cleaned: " + cleanedBones + "/" + (maxBones + 1);
    }
    
    public void PolishToggleTextChange(int polishedBones, int maxBones)
    {
        polishToggleText.text = "Polish Bones. Polished: " + polishedBones + "/" + (maxBones + 1);
    }

    public void CombineToggleOn()
    {
        Combinetoggle.isOn = true;
        putTogetherDisplay.SetActive(false);
        //txtScribeSteps.text = "Hold left trigger to polish the fossil!";
    }

    public void CombineToggleOff()
    {
        Combinetoggle.isOn = false;
        putTogetherDisplay.SetActive(false);
        //txtScribeSteps.text = "Hold left trigger to polish the fossil!";
    }


    public void PolishToggleOn()
    {
        Polishtoggle.isOn = true;
        //txtScribeSteps.text = "Great job. The fossil will be displayed in the museum soon!";
    }


    public void PolishToggleOff()
    {
        Polishtoggle.isOn = false;
        //txtScribeSteps.text = "Great job. The fossil will be displayed in the museum soon!";
    }
    public void PlayTaskCompleteAudio()
    {
        successAudio?.Play();
    }

    public void IdentifyToggleOn()
    {
        Identifytoggle.isOn = true;
        //txtScribeSteps.text = "Great job. The fossil will be displayed in the museum soon!";
    }

    public void IdentifyToggleOff()
    {
        Identifytoggle.isOn = false;
        //txtScribeSteps.text = "Great job. The fossil will be displayed in the museum soon!";
    }

    public void PlayFullCompleteAudio()
    {
        successAudio.clip = clips[1];
        successAudio?.Play();
    }
}
