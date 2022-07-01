using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBreak : MonoBehaviour
{
    public List<GameObject> RockPieces;
    public GameObject breakParticle;
    public GameObject cBreakParticle;

    public bool BreakPiece()
    {
        cBreakParticle = Instantiate(breakParticle);
        Destroy(cBreakParticle, 1.5f);

        //Finish Removal
        if (RockPieces.Count == 0)
        {
            DestroyRock();
            return true;
        }

        int ranNum = Random.Range(0, RockPieces.Count);

        //Decreases rockpiece durability
        if (RockPieces[ranNum].GetComponent<Rock>().breakPoint >= 0)
        {
            RockPieces[ranNum].GetComponent<Rock>().breakPoint--;
        }
        //Drops and destroys rock piece when durability is gone
        else 
        {
            RockPieces[ranNum].GetComponent<Rigidbody>().useGravity = true;

            Destroy(RockPieces[ranNum], 1.5f);
            RockPieces.RemoveAt(ranNum);
        }
        return false;
    }

    //Destroys Rock collider
    public void DestroyRock()
    { 
        Destroy(gameObject, 2f);
    }
}
