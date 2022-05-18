using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AirScribe : MonoBehaviour
{
    enum CleaningGameState
    {
        ROCKBREAK,
        DUSTING,
        COMBINE,
        POLISH,
        IDENTIFY
    }

    static CleaningGameState currentState;
    public Combineable currentBone;
    public CleaningUIManager cUIManager;
    public TestVRInput VRInput;

    public JournalManager JManager;

    int piecesCleaned = 0;
    int piecesPolished = 0;
    bool combined = false;

    private void Awake()
    {
        currentState = CleaningGameState.ROCKBREAK;
        currentBone = FindObjectOfType<Combineable>();
        cUIManager.CleanToggleTextChange(piecesCleaned, currentBone.boneParts.Count);
        cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);
        JManager = FindObjectOfType<JournalManager>();
    }

    private void Update()
    {

    }


    /// <summary>
    /// Cleaning Game State Layout
    /// </summary>
    public void CleaningState(Collider collidedObject)
    {
        switch (currentState)
        {
            case CleaningGameState.ROCKBREAK:
                if (collidedObject.transform.gameObject.CompareTag("Rock"))
                {
                    if (collidedObject.transform.gameObject.GetComponent<StoneBreak>().BreakPiece())
                    {

                        cUIManager.RockBreakToggleChange();

                        currentState = CleaningGameState.DUSTING;

                    }

                }

                break;
            case CleaningGameState.DUSTING:
                if (collidedObject.transform.gameObject.CompareTag("Bone"))
                {
                    if (collidedObject.transform.gameObject.GetComponent<Dusting>().ChangeMaterial(combined) == 3)
                    {
                        piecesCleaned++;
                        cUIManager.CleanToggleTextChange(piecesCleaned, currentBone.boneParts.Count);
                        if (piecesCleaned == currentBone.boneParts.Count + 1)
                        {
                            cUIManager.CleanToggleChange();
                            currentState = CleaningGameState.COMBINE;
                        }

                    }
                }

                break;
            case CleaningGameState.COMBINE:
                if (currentBone.GetBoneCounter() == currentBone.boneParts.Count)
                {
                    combined = true;
                    cUIManager.CombineToggleChange();
                    currentState = CleaningGameState.POLISH;
                }
                break;

            case CleaningGameState.POLISH:
                Debug.Log("Enter Polish");
                if (collidedObject.transform.gameObject.CompareTag("Bone"))
                {
                    if (collidedObject.transform.gameObject.GetComponent<Dusting>().ChangeMaterial(combined) == -1)
                    {
                        piecesPolished++;
                        cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);

                        if (piecesPolished == currentBone.boneParts.Count + 1)
                        {
                            cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);

                            cUIManager.PolishToggleChange();

                            FossilHolder.FossilFound("Utahraptor");

                            currentState = CleaningGameState.IDENTIFY;
                        }
                    }
                }

                break;
            case CleaningGameState.IDENTIFY:
                Debug.Log("Identify");
                JManager.IdentifyReady = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Bone") || other.transform.gameObject.CompareTag("Rock"))
        {
            CleaningState(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
