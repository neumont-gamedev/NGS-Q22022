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
    public GameObject collideobject;

    public FossilHolder holder;




    // Update is called once per frame

    public void StartCleanProcess()
    {
        currentBone = FindObjectOfType<Combineable>();
        holder = FindObjectOfType<FossilHolder>();
        cuiManager.CUIMCheckReset();
        cState = CleanState.ROCKBREAK;
        Debug.Log("Cleaned Bones:" + currentBone.cleanedCounter);
        Debug.Log("Total Bones:" + currentBone.boneParts.Count);
        cuiManager.CleanToggleTextChange(currentBone.cleanedCounter, currentBone.boneParts.Count);
        cuiManager.PolishToggleTextChange(currentBone.polishCounter, currentBone.boneParts.Count);
        Debug.Log(cState.ToString());
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
                    cuiManager.RockBreakToggleOn();
                    cuiManager.PlayTaskCompleteAudio();
                    cState = CleanState.DUSTING;
                    Debug.Log(cState.ToString());

                }
                break;
            case CleanState.DUSTING:

                //check if bone needs to be cleaned
                //if not add to the counter
                //if counter is equal to number of bones go to next stage

                if(collided.transform.gameObject.CompareTag("Bone"))
                {
                    Debug.Log("Bone Hit");
                    if(collided.GetComponent<Dusting>().ChangeMaterial())
                    {
                        currentBone.cleanedCounter++;
                        cuiManager.CleanToggleTextChange(currentBone.cleanedCounter, currentBone.boneParts.Count);

                        if (currentBone.cleanedCounter == currentBone.boneParts.Count + 1) // if all bones are cleaned change state
                        {
                            currentBone.IsClean();
                            cuiManager.CleanToggleOn();
                            cuiManager.PlayTaskCompleteAudio();
                            cState = CleanState.COMBINE;
                        }
                    }
                }


                break;


            case CleanState.COMBINE:
                Debug.Log("Current Action: " + cState.ToString());
                if (currentBone.GetBoneCounter())
                {
                    cuiManager.CombineToggleOn();
                    cuiManager.PlayTaskCompleteAudio();
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
                        cuiManager.PolishToggleOn();

                        //FossilHolder.Instance.FossilFound(holder.firstFossil());
                        holder.FossilFound(holder.firstFossil());
                        cuiManager.PlayTaskCompleteAudio();
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
        collideobject = other.transform.gameObject;
        if (collideobject.CompareTag("Bone") || collideobject.CompareTag("Rock")) 
        {
            Clean(other);
        }
    }


}
