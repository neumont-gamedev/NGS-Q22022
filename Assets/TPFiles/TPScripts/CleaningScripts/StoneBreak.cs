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

    public TestPhysicsPointer physicsPointer;

    public bool BreakPiece()
    {

        cBreakParticle = Instantiate(breakParticle);
        Destroy(cBreakParticle, 1.5f);
        numofPiecesToBreak = RockPieces.Count;

        int ranNum = Random.Range(0, RockPieces.Count);

        if (RockPieces.Count == 0)
        {

            DestroyRock();
            return true;

        }

        else if (RockPieces[ranNum].GetComponent<Rock>().breakPoint >= 0)
        {
            RockPieces[ranNum].GetComponent<Rock>().breakPoint--;
            return false;
        }
        else 
        {
            RockPieces[ranNum].GetComponent<Rigidbody>().useGravity = true;

            Destroy(RockPieces[ranNum], 1.5f);
            RockPieces.RemoveAt(ranNum);
            return false;
        }
    }

    public void DestroyRock()
    { 
        gameObject.GetComponent<Collider>();
        Debug.Log("All Broken Off");
        Destroy(gameObject, 2f);
    }
}
