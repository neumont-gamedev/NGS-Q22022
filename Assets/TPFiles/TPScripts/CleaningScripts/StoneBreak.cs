using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBreak : MonoBehaviour
{
    public List<GameObject> RockPieces; // number of pieces to break

    public bool BreakPiece() 
    {
        int ranNum = Random.Range(0, RockPieces.Count); //ger random rock between all that's left
        Rock curRock = null;

        //Finish Removal
        if (RockPieces.Count == 0)
        {
            DestroyRock();
            return true; // return null when all rocks broken
        }

        curRock = RockPieces[ranNum].GetComponent<Rock>();

        //Decreases rockpiece durability
        if (curRock.breakPoint > 0)
        {
            curRock.breakPoint--;
        }

        //Drops and destroys rock piece when durability is gone
        else
        {
            curRock.GetComponent<Rigidbody>().useGravity = true;

            Destroy(curRock, 1.5f);
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
