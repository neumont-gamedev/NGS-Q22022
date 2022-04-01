using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BoneData", menuName = "Data/BoneData")]
public class BoneData : ScriptableObject
{
    public string CreatureName;
    public string OtherName;
    public string CreatureFact;
    public int PieceNum;

}