using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBreak : MonoBehaviour
{
    public List<GameObject> RockPieces;
    public GameObject breakParticle;
    public GameObject cBreakParticle;
    static int numofPiecesToBreak;
    //public int numofPieces;
    //int curlength;

    public void BreakPiece()
    {
        numofPiecesToBreak = RockPieces.Count;

        int ranNum = Random.Range(0, RockPieces.Count);

        RockPieces[ranNum].GetComponent<Rigidbody>().useGravity = true;
        Destroy(RockPieces[ranNum], 1.5f);
        RockPieces.RemoveAt(ranNum);

        if(RockPieces.Count == 0)
        {
            DestroyRock();
        }

    }

    public void DestroyRock()
    {
            Debug.Log("All Broken Off");
            Destroy(gameObject, 2f);
    }
}
