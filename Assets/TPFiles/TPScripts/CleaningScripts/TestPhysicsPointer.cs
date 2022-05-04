using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TestPhysicsPointer : MonoBehaviour
{
    enum CleaningGameState
    {
        ROCKBREAK,
        DUSTING,
        COMBINE,
        POLISH,
        IDENTIFY
    }


    public CleaningUIManager cUIManager;
    public float defaultLength = 1.0f;
    LineRenderer lineRenderer;
    public TestVRInput VRInput;
    Vector3 endPosition;

    int piecesCleaned = 0;
    int piecesPolished = 0;
    bool combined = false;


    static CleaningGameState currentState;

    public Combineable currentBone;

    /// <summary>
    /// Cleaning Game State Layout
    /// </summary>
    /// 

    private void CleaningState()
    {
        RaycastHit hit;
        Ray ray = new Ray(endPosition, transform.forward);

        switch (currentState)
        {
            case CleaningGameState.ROCKBREAK:
                if (Physics.Raycast(ray, out hit, endPosition.magnitude))
                {
                    if (hit.transform.gameObject.CompareTag("Rock"))
                    {
                        if(hit.transform.gameObject.GetComponent<StoneBreak>().BreakPiece())
                        {

                            cUIManager.RockBreakToggleChange();

                            currentState = CleaningGameState.DUSTING;

                        }
                    }
                }
                break;
            case CleaningGameState.DUSTING:
                if (Physics.Raycast(ray, out hit, endPosition.magnitude))
                {
                if(hit.transform.gameObject.CompareTag("Bone"))
                    {
                        if(hit.transform.gameObject.GetComponent<Dusting>().ChangeMaterial(combined) == 3)
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
                }
                break;

            case CleaningGameState.COMBINE:
/*                Debug.Log("Enter Combine");
                Debug.Log("Bone Counter : " + currentBone.GetBoneCounter());
                Debug.Log("Bone Counter With Public Var : " + currentBone.combinedBoneCounter);
                Debug.Log("Bone Parts Count : " + currentBone.boneParts.Count);*/
                if (currentBone.GetBoneCounter() == currentBone.boneParts.Count)
                {
                    combined = true;
                    cUIManager.CombineToggleChange();
                    currentState = CleaningGameState.POLISH;
                }
                break;

            case CleaningGameState.POLISH:
                Debug.Log("Enter Polish");

                if (Physics.Raycast(ray, out hit, endPosition.magnitude))
                {
                    if (hit.transform.gameObject.CompareTag("Bone"))
                    {
                        if (hit.transform.gameObject.GetComponent<Dusting>().ChangeMaterial(combined) == -1)
                        {
                            piecesPolished++;
                            cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);

                            if (piecesPolished == currentBone.boneParts.Count + 1)
                            {
                                cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);

                                cUIManager.PolishToggleChange();

                                //set cur fossil.clean to true;
                                Fossil temp = FossilHolder.backpack.Find(f => f.name == "UtahRaptor");
                                
                                if(temp != null)
                                {
                                    temp.cleaned = true;
                                    FossilHolder.FossilFound(temp);
                                }
                                currentState = CleaningGameState.IDENTIFY;
                            }
                        }
                    }
                }
                break;
            case CleaningGameState.IDENTIFY:
                Debug.Log("Identify");
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        currentBone = FindObjectOfType<Combineable>();
        cUIManager.CleanToggleTextChange(piecesCleaned, currentBone.boneParts.Count);
        cUIManager.PolishToggleTextChange(piecesPolished, currentBone.boneParts.Count);
    }

    private void Update()
    {
        if (VRInput.GetMouseButtonDown(0))
        {
            CleaningState();
        }
    }

    /// <summary>
    /// Raycast Line Renderer
    /// </summary>

    private void LateUpdate()
    {
        UpdateLength();
    }

    private void UpdateLength()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, CalculateEnd());
    }

    private Vector3 CalculateEnd()
    {
        RaycastHit hit = CreateForwardRaycast();
        endPosition = DefaultEnd(defaultLength);

        if (hit.collider)
        {
            endPosition = hit.point;
        }

        return endPosition;
    }

    private RaycastHit CreateForwardRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);

        Physics.Raycast(ray, out hit, defaultLength);

        return hit;
    }

    private Vector3 DefaultEnd(float length)
    {
        return transform.position + (transform.forward * length);
    }


}
