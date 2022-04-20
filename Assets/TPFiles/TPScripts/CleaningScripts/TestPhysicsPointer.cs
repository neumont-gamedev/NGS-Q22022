using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TestPhysicsPointer : MonoBehaviour
{
    public float defaultLength = 1.0f;
    LineRenderer lineRenderer;
    public TestVRInput VRInput;
    Vector3 endPosition;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
            

        UpdateLength();

        if (VRInput.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(VRInput.mousePosition);
            if (Physics.Raycast(ray, out hit, endPosition.magnitude) && hit.transform.tag == "Rock")
            {
                Debug.Log("Rock Clicked");
                hit.transform.gameObject.GetComponent<StoneBreak>().BreakPiece();
            }

            if (Physics.Raycast(ray, out hit, endPosition.magnitude) && hit.transform.tag == "Bone")
            {
                hit.transform.gameObject.GetComponent<Dusting>().ChangeMaterial();
                Debug.Log("Bone Clicked");

            }
        }
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
