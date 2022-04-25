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
        IDENTIFY
    }


    public float defaultLength = 1.0f;
    LineRenderer lineRenderer;
    public TestVRInput VRInput;
    Vector3 endPosition;

    static CleaningGameState currentState;

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
                        if(hit.transform.gameObject.GetComponent<Dusting>().ChangeMaterial() == 3)
                        {
                            currentState = CleaningGameState.COMBINE;
                        }
                        else if (hit.transform.gameObject.GetComponent<Dusting>().ChangeMaterial() == 4)
                        {
                            currentState = CleaningGameState.IDENTIFY;
                        }
                        Debug.Log("Bone Clicked");
                    }
                }
                Debug.Log("Currently on Dusting");
                break;
            case CleaningGameState.COMBINE:
                


                Debug.Log("Currently on Combine");

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
