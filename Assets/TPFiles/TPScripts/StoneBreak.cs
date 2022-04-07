using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBreak : MonoBehaviour
{
    public GameObject[] RockPieces;
    int pieceNextToBreak = -1;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Click");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100.0f) && hit.transform.tag == "Rock"){
                if (pieceNextToBreak > RockPieces.Length)
                {
                    
                    pieceNextToBreak += 0;
                    Debug.Log(pieceNextToBreak);
                }
                else
                {
                    pieceNextToBreak++;
                    BreakPiece();
                    Debug.Log(pieceNextToBreak);
                }
            
            }
        }
    }

    public void BreakPiece()
    {
        if(pieceNextToBreak == RockPieces.Length)
        {
            Debug.Log("All Broken Off");
        }
        else
        {
            RockPieces[pieceNextToBreak].GetComponent<Rigidbody>().useGravity = true;
            //Destroy(RockPieces[pieceNextToBreak]);
            Debug.Log("Pieces Left: " + pieceNextToBreak);
        }
    }
}
