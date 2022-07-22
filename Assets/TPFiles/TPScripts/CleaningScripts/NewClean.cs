using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClean : MonoBehaviour
{
    //State of where cleaning is currently
    //maybe have a button the player pressed to advance to the next stage
    enum CleanState
    {
        START,
        ROCKBREAK, //chipping off rock pieces
        DUSTING, //change material 3 times
        COMBINE, //piece fossil back together
        POLISH, //1 more material change
        IDENTIFY, //journal? (Might totally remove)
        DONE //count fossil as complete
    }

    //Variables
    static CleanState cState = CleanState.START; //current state
    public Combineable currentBone; //what bone is being messed with
    public CleaningUIManager cuiManager; //uiManagement

    public FossilHolder holder;

    //Bone Counts


    // Start is called before the first frame update
    void Start()
    {
        cState = CleanState.START;
        holder = FindObjectOfType<FossilHolder>();
    }

    public void EndClean()
    {
        cState = CleanState.ROCKBREAK;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCleanProcess()
    {
        cState = CleanState.ROCKBREAK;
        cuiManager.CleanToggleTextChange(currentBone.cleanedCounter, currentBone.boneParts.Count);
        cuiManager.PolishToggleTextChange(currentBone.polishCounter, currentBone.boneParts.Count);
    }

    public void Clean(Collider collidedObject)
    {
        GameObject collided = collidedObject.transform.gameObject;
        switch (cState) // switch dependant on state of cleaning
        {
            case CleanState.START:
  
                break;
            case CleanState.ROCKBREAK:
                if (currentBone.GetComponent<StoneBreak>().BreakPiece()) //if true is returned go to next state
                {
                    cState = CleanState.DUSTING;
                }
                break;
            case CleanState.DUSTING:
                if (collided.transform.gameObject.CompareTag("Bone"))
                {
                    currentBone.cleanedCounter++;
                    cuiManager.CleanToggleTextChange(currentBone.cleanedCounter, currentBone.boneParts.Count);
                    if(collided.GetComponent<Dusting>().ChangeMaterial())
                    {
                        if (currentBone.cleanedCounter >= currentBone.boneParts.Count + 1)
                        {
                            currentBone.Clean();
                            cuiManager.CleanToggleChange();
                            cState = CleanState.COMBINE;
                        }
                    }
                
                }
                break;
            case CleanState.COMBINE:
                if (currentBone.GetBoneCounter())
                {
                    cuiManager.CombineToggleChange();
                    cState = CleanState.POLISH;
                }
                break;
            case CleanState.POLISH:
                if (collided.GetComponent<Dusting>().PolishChange())
                {
                    currentBone.polishCounter++;
                    cuiManager.PolishToggleTextChange(currentBone.polishCounter, currentBone.boneParts.Count);

                    if (currentBone.polishCounter == currentBone.boneParts.Count + 1)
                    {
                        cuiManager.PolishToggleChange();

                        FossilHolder.Instance.FossilFound(holder.firstFossil());

                        cState = CleanState.IDENTIFY;
                    }
                }
                break;
            case CleanState.IDENTIFY:
                cState = CleanState.DONE;
                break;
            case CleanState.DONE:

                //cState = CleanState.START;
                break;
            default:
                break;
        }
    }


}
