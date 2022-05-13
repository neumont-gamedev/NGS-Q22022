using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdentifyData", menuName = "Data/IdentifyData")]
public class IdentifyData : ScriptableObject
{
    public string Markings;
    public string What_Happened;
    public string Body_Part;
    public string Creature_Name;
    public string FinalAnswer;

}
