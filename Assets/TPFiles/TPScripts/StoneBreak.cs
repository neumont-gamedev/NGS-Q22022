using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBreak : MonoBehaviour
{
    public GameObject[] RockPieces;
    public GameObject breakParticle;
    public GameObject cBreakParticle;
    public int numofPieces = 0;
    int curlength;

    public void Start()
    {
       curlength =  RockPieces.Length - 1;
    }

    public void HitHandle()
    {
            //pieceNextToBreak++;
            BreakPiece();
            //Debug.Log(pieceNextToBreak);
    }

    public void BreakPiece()
    {

        int ranNum;
        do
        {
            ranNum = Random.Range(0, curlength);

            cBreakParticle = Instantiate(breakParticle, breakParticle.transform.position, transform.rotation);
            Destroy(cBreakParticle, 1.5f);
            RockPieces[ranNum].GetComponent<Rigidbody>().useGravity = true;
            Destroy(RockPieces[ranNum], 2.5f);
            //Destroy(RockPieces[pieceNextToBreak]);
            Debug.Log("Pieces Left: " + "test");
        }
        while (RockPieces[ranNum] != null);
    }

    public void DestroyRock()
    {
            Debug.Log("All Broken Off");
            Destroy(gameObject, 2f);
    }
}
