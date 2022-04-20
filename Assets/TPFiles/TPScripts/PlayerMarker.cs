using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Will Be Child Class of MapMarker
public class PlayerMarker : MonoBehaviour
{
    public GameObject player;
    public Image image;
    public RectTransform rectTransform;
    public string playerTag = "Player";
    public Color color = Color.white;

    void Start()
    {
        if (player == null) player = GameObject.FindWithTag(playerTag);
        if (image == null) image = GetComponent<Image>();
        if (rectTransform == null) rectTransform = gameObject.GetComponent<RectTransform>();

        image.color = color;
        SetPositionAndRotation();
    }

    void Update()
    {
        SetPositionAndRotation();
    }

    void SetPositionAndRotation()
    {
        rectTransform.localPosition = new Vector3(player.transform.position.x / 50f, player.transform.position.z / 50f, -0.51f);
    }
}
