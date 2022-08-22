using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlaqueManager : MonoBehaviour
{
    public DataHolder m_dino;
    public GameObject m_plaque;
    public List<TMP_Text> textList;
    public List<UnityEngine.UI.Image> plaqueImageList;
    public List<Sprite> partList;
    public List<Sprite> markingList;
    public List<Sprite> creatureList;

    void Awake()
    {
        //Checks if the Data holder is exists and has values other than default, deactivates and hides the plaques from view if not the case.
        if (m_dino != null)
        {
            if ((m_dino.boneData.Markings != "default") && (m_dino.boneData.Body_Part != "default") && (m_dino.boneData.Creature_Name != "default"))
            {
                UpdatePlaque();
            }
            else m_plaque.SetActive(false);
        }
        else m_plaque.SetActive(false);
    }

    public void UpdatePlaque()
    {
        //Updates Plaque if the referenced DataHolder contains the IdentifyData and the Identify Data has actual values in it.
        Debug.Log("Attempted to Update Plaque");
        textList[0].text = m_dino.boneData.Body_Part;
        textList[1].text = m_dino.boneData.Markings;
        textList[2].text = m_dino.boneData.Creature_Name;
        plaqueImageList[0].sprite = GetPictures(m_dino.boneData.Body_Part);
        plaqueImageList[1].sprite = GetPictures(m_dino.boneData.Markings);
        plaqueImageList[2].sprite = GetPictures(m_dino.boneData.Creature_Name);

    }

    public Sprite GetPictures(string input)
    {
        //returns the correct Image to display in Update Plaque -J
        Sprite result;
        switch (input)
        {
            case "Head":
                result = partList[0];
                break;
            case "Tail":
                result = partList[1];
                break;
            case "Foot":
                result = partList[2];
                break;
            case "Pelvis":
                result = partList[3];
                break;
            case "Scratch":
                result = markingList[0];
                break;
            case "Holes":
                result = markingList[1];
                break;
            case "Bug Bites":
                result = markingList[2];
                break;
            case "Fractures":
                result = markingList[3];
                break;
            case "Allosaurus":
                result = creatureList[0];
                break;
            case "Trilobite":
                result = creatureList[1];
                break;
            case "Trex":
                result = creatureList[2];
                break;
            case "UtahRaptor":
                result = creatureList[3];
                break;
            case "Triceratops":
                result = creatureList[4];
                break;
            default:
                result = partList[0];
                break;
        }
        return result;
    }
}