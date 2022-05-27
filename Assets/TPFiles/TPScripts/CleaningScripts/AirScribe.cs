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
    [SerializeField] GameObject scribeDescriptionPanel;

    public JournalManager JManager;
    FossilHolder holder;

    int piecesCleaned = 0;
    int piecesPolished = 0;

    private void Awake()
    {
        currentState = CleaningGameState.ROCKBREAK;
        currentBone = FindObjectOfType<Combineable>();
        holder = FindObjectOfType<FossilHolder>();
        cUIManager.CleanToggleTextChange(piecesCleaned, currentBone.boneParts.Count);
        cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);
        JManager = FindObjectOfType<JournalManager>();
        if (scribeDescriptionPanel != null) scribeDescriptionPanel.SetActive(true);
    }

    /// <summary>
    /// Cleaning Game State Layout
    /// </summary>
    public void CleaningState(Collider collidedObject)
    {
        GameObject collided = collidedObject.transform.gameObject;
        switch (currentState)
        {
            case CleaningGameState.ROCKBREAK:
                if (collided.CompareTag("Rock"))
                {
                    if (collided.GetComponent<StoneBreak>().BreakPiece())
                    {

                        cUIManager.RockBreakToggleChange();

                        currentState = CleaningGameState.DUSTING;

                    }

                }

                break;
            case CleaningGameState.DUSTING:
                if (collided.CompareTag("Bone"))
                {
                    if (collided.GetComponent<Dusting>().ChangeMaterial())
                    {
                        piecesCleaned++;
                        cUIManager.CleanToggleTextChange(piecesCleaned, currentBone.boneParts.Count);
                        if (piecesCleaned >= currentBone.boneParts.Count + 1)
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
                    cUIManager.CombineToggleChange();
                    currentState = CleaningGameState.POLISH;
                }
                break;

            case CleaningGameState.POLISH:
                if (collided.CompareTag("Bone"))
                {
                    if (collided.GetComponent<Dusting>().PolishChange())
                    {
                        piecesPolished++;
                        cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);

                        if (piecesPolished == currentBone.boneParts.Count + 1)
                        {
                            cUIManager.PolishToggleChange();

                            FossilHolder.FossilFound(holder.backpackContents()[0]);

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
}
