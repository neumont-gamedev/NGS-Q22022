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
        IDENTIFY,
        DONE
    }

    static CleaningGameState currentState = CleaningGameState.ROCKBREAK;
    public Combineable currentBone;
    public CleaningUIManager cUIManager;

    public List<MeshCollider> grabMeshes = new List<MeshCollider>();

    JournalManager JManager;
    FossilHolder holder;

    int piecesCleaned = 0;
    int piecesPolished = 0;

    private void Start()
    {
        currentState = CleaningGameState.ROCKBREAK;

        foreach(var b in GameObject.FindGameObjectsWithTag("Bone"))
        {
            grabMeshes?.Add(b.GetComponent<MeshCollider>());
        }
        var temp = grabMeshes.ToArray();

        foreach(var l in temp) { l.enabled = false; }

        currentBone = FindObjectOfType<Combineable>();
        JManager = FindObjectOfType<JournalManager>();
        holder = FindObjectOfType<FossilHolder>();

        cUIManager.CleanToggleTextChange(piecesCleaned, currentBone.boneParts.Count);
        cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);
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
                if (collided.GetComponent<StoneBreak>().BreakPiece())
                {
                    cUIManager.RockBreakToggleChange();
                    currentState = CleaningGameState.DUSTING;

                    var temp = grabMeshes.ToArray();
                    foreach(var b in temp) { b.enabled = true; }
                }
                break;
            case CleaningGameState.DUSTING:
                if (collided.transform.gameObject.CompareTag("Bone"))
                {
                    if (collided.GetComponent<Dusting>().ChangeMaterial())
                    {
                        piecesCleaned++;
                        cUIManager.CleanToggleTextChange(piecesCleaned, currentBone.boneParts.Count);
                        if (piecesCleaned >= currentBone.boneParts.Count + 1)
                        {
                            currentBone.Clean();
                            cUIManager.CleanToggleChange();
                            currentState = CleaningGameState.COMBINE;
                        }
                    }
                }
                break;
            case CleaningGameState.COMBINE:
                if (currentBone.GetBoneCounter())
                {
                    cUIManager.CombineToggleChange();
                    currentState = CleaningGameState.POLISH;
                }
                break;

            case CleaningGameState.POLISH:
                if (collided.GetComponent<Dusting>().PolishChange())
                {
                    piecesPolished++;
                    cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);

                    if (piecesPolished == currentBone.boneParts.Count + 1)
                    {
                        cUIManager.PolishToggleChange();

                        FossilHolder.Instance.FossilFound(holder.firstFossil());

                        currentState = CleaningGameState.IDENTIFY;
                    }
                }
                break;
            case CleaningGameState.IDENTIFY:
                //JManager.IdentifyReady = true;
                break;
            case CleaningGameState.DONE:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var bro = other.transform.gameObject;
        if (bro.CompareTag("Bone") || bro.CompareTag("Rock"))
        {
            CleaningState(other);
        }
    }
}
