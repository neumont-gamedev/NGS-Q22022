using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningUIManager : MonoBehaviour
{

    public Toggle RockBreaktoggle;
    public Toggle Cleantoggle;
    public Text cToggleText;


    public Toggle Combinetoggle;
    public Toggle Polishtoggle;
    public Text polishToggleText;

    public GameObject putTogetherDisplay;


    public void RockBreakToggleChange()
    {
        Polishtoggle.isOn = false;
        RockBreaktoggle.isOn = true;
    }

    public void CleanToggleChange()
    {
        Polishtoggle.isOn = false;
        Cleantoggle.isOn = true;
        putTogetherDisplay.SetActive(true);
    }

    public void CleanToggleTextChange(int cleanedBones, int maxBones)
    {
        cToggleText.text = "Clean Bones. Cleaned: " + cleanedBones + "/" + (maxBones + 1);
    }
    
    public void PolishToggleTextChange(int polishedBones, int maxBones)
    {
        polishToggleText.text = "Polish Bones. Polished: " + polishedBones + "/" + (maxBones + 1);
    }

    public void CombineToggleChange()
    {
        Polishtoggle.isOn = false;
        Combinetoggle.isOn = true;
        putTogetherDisplay.SetActive(false);
    }


    public void PolishToggleChange()
    {
        Polishtoggle.isOn = true;
    }


}
