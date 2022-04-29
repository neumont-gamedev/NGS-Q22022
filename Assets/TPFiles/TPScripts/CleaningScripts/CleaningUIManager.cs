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


    public void RockBreakToggleChange()
    {
        RockBreaktoggle.isOn = true;
    }

    public void CleanToggleChange()
    {
        
        Cleantoggle.isOn = true;
    }

    public void CleanToggleTextChange(int cleanedBones, int maxBones)
    {
        cToggleText.text = "Clean Bones  - Bones Cleaned: " + cleanedBones + "/" + maxBones;
        Cleantoggle.isOn = true;
    }

    public void CombineToggleChange()
    {
        Combinetoggle.isOn = true;
    }


    public void PolishToggleChange()
    {
        Polishtoggle.isOn = true;
    }


}
