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
                        Debug.Log("Rock Clicked");
                        if(hit.transform.gameObject.GetComponent<StoneBreak>().BreakPiece())
                        {
                            currentState = CleaningGameState.DUSTING;
                        }
                    }
                }
                    Debug.Log("Currently on Rock Break");
                break;
            case CleaningGameState.DUSTING:
                if (Physics.Raycast(ray, out hit, endPosition.magnitude))
                {
                if(hit.transform.gameObject.CompareTag("Bone"))
                    {
                        if(hit.transform.gameObject.GetComponent<Dusting>().ChangeMaterial(combined) == 3)
                        {
                            piecesCleaned++;
                            if (piecesCleaned == currentBone.boneParts.Count + 1)
                            {
                                Debug.Log("All Clean");
                                currentState = CleaningGameState.COMBINE;
                            }
                           
                        }
                        Debug.Log("Bone Clicked");
                    }
                }
                Debug.Log("Currently on Dusting");
                break;

            case CleaningGameState.COMBINE:
                Debug.Log("Enter Combine");
                Debug.Log("Bone Counter : " + currentBone.GetBoneCounter());
                Debug.Log("Bone Counter With Public Var : " + currentBone.combinedBoneCounter);
                Debug.Log("Bone Parts Count : " + currentBone.boneParts.Count);
                if (currentBone.GetBoneCounter() == currentBone.boneParts.Count)
                {
                    combined = true;
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
                            Debug.Log("Bruh" + hit.transform.gameObject.name);
                            piecesPolished++;
                            if (piecesPolished == currentBone.boneParts.Count + 1)
                            {
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
    }

    private void Update()
    {
       
        Debug.Log(currentState);
        Debug.Log("Pieces Cleaned: " + piecesCleaned);
        Debug.Log("Number of bone Pieces: " + currentBone.GetBoneCounter());


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
