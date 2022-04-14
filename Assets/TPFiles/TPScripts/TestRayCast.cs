using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TestRayCast : MonoBehaviour
{
    public TestVRInput VRInput;

    //public void OnPointerClick(PointerEventData eventData)
    //{
    //    if (VRInput.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(VRInput.mousePosition);
    //        if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.tag == "Rock")
    //        {
    //            Debug.Log("Rock Clicked");
    //            hit.transform.gameObject.GetComponent<StoneBreak>().BreakPiece();
    //        }
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (VRInput.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(VRInput.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.tag == "Rock")
            {
                Debug.Log("Rock Clicked");
                hit.transform.gameObject.GetComponent<StoneBreak>().BreakPiece();
            }
        }
    }
}
