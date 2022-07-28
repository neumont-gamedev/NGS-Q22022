using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewClean : MonoBehaviour
{
    //State of where cleaning is currently
    //maybe have a button the player pressed to advance to the next stage
    enum CleanState
    {

        ROCKBREAK, //chipping off rock pieces
        DUSTING, //change material 3 times
        COMBINE, //piece fossil back together
        POLISH, //1 more material change
        IDENTIFY, //journal? (Might totally remove)
        DONE //count fossil as complete
    }

    //Variables
    static CleanState cState = CleanState.ROCKBREAK;//current state
    public Combineable currentBone; //what bone is being messed with
    public CleaningUIManager cuiManager; //uiManagement

    public FossilHolder holder;

    //Bone Counts
    void Awake()
    {
        currentBone = FindObjectOfType<Combineable>();
        holder = FindObjectOfType<FossilHolder>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame

    public void StartCleanProcess()
    {
        cState = CleanState.ROCKBREAK;
        Debug.Log(cState.ToString());
        //cuiManager.CleanToggleTextChange(currentBone.cleanedCounter, currentBone.boneParts.Count);
        //cuiManager.PolishToggleTextChange(currentBone.polishCounter, currentBone.boneParts.Count);
    }

    public void EndClean()
    {
        cState = CleanState.ROCKBREAK;
    }

    public void Clean(Collider collidedObject)
    {
        GameObject collided = collidedObject.transform.gameObject;
        switch (cState) // switch dependant on state of cleaning
        {
            case CleanState.ROCKBREAK:
                //Debug.Log("Current Action: "+ cState.ToString());
                if (collided.GetComponent<StoneBreak>().BreakPiece()) //if true is returned go to next state
                {
                    foreach (MeshCollider dust in currentBone.grabMeshes)
                    {
                        dust.enabled = true;
                    }
                    cState = CleanState.DUSTING;
                }
                break;
            case CleanState.DUSTING:
                //Debug.Log("Current Action: " + cState.ToString());
                if (collided.transform.gameObject.CompareTag("Bone")) // check if bone struck
                {
                    if(collided.GetComponent<Dusting>().ChangeMaterial()) //checks if needs to clean
                    {
                        Debug.Log(currentBone.cleanedCounter);
                        currentBone.cleanedCounter++;
                        Debug.Log(currentBone.cleanedCounter);
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
                Debug.Log("Current Action: " + cState.ToString());
                if (currentBone.GetBoneCounter())
                {
                    //cuiManager.CombineToggleChange();
                    cState = CleanState.POLISH;
                }
                break;
            case CleanState.POLISH:
                Debug.Log("Current Action: " + cState.ToString()); if (collided.GetComponent<Dusting>().PolishChange())
                {
                    currentBone.polishCounter++;
                    //cuiManager.PolishToggleTextChange(currentBone.polishCounter, currentBone.boneParts.Count);

                    if (currentBone.polishCounter == currentBone.boneParts.Count + 1)
                    {
                        cuiManager.PolishToggleChange();

                        FossilHolder.Instance.FossilFound(holder.firstFossil());

                        cState = CleanState.IDENTIFY;
                    }
                }
                break;
            case CleanState.IDENTIFY:
                Debug.Log("Current Action: " + cState.ToString());
                Debug.Log(cState);
                cState = CleanState.DONE;
                break;
            case CleanState.DONE:

                //cState = CleanState.START;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var bro = other.transform.gameObject;
        if (bro.CompareTag("Bone") || bro.CompareTag("Rock")) { Clean(other);}
    }


}
