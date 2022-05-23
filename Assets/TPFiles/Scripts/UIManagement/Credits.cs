using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float resetPoint = -100f;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.localPosition = new Vector3(rect.localPosition.x, 
                                         rect.localPosition.y + (scrollSpeed * Time.deltaTime), 
                                         rect.localPosition.z);

        if (rect.localPosition.y >= resetPoint)
        {
            rect.localPosition = new Vector3(rect.localPosition.x,
                                             0,
                                             rect.localPosition.z);
        }
    }
}
