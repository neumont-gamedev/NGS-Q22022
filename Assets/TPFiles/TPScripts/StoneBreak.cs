using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBreak : MonoBehaviour
{
    public GameObject[] RockPieces;
    public GameObject breakParticle;
    public GameObject cBreakParticle;
    public int pieceNextToBreak = -1;
    bool beenHit = false;

    public void HitHandle()
    {

            pieceNextToBreak++;
            BreakPiece();
            Debug.Log(pieceNextToBreak);
    }

    public void BreakPiece()
    {
        if(pieceNextToBreak > RockPieces.Length-1)
        {
            Debug.Log("All Broken Off");
            Destroy(gameObject, 2f);
        }
        else
        {
            cBreakParticle = Instantiate(breakParticle, breakParticle.transform.position, transform.rotation);
            Destroy(cBreakParticle, 1.5f);

            RockPieces[pieceNextToBreak].GetComponent<Rigidbody>().useGravity = true;
            Destroy(RockPieces[pieceNextToBreak], 2.5f);
            if(pieceNextToBreak == RockPieces.Length-1)
            {
                pieceNextToBreak += 1;
                BreakPiece();
            }
            //Destroy(RockPieces[pieceNextToBreak]);
            Debug.Log("Pieces Left: " + pieceNextToBreak);
        }
    }
}
