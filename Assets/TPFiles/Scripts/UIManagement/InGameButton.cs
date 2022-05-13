using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class InGameButton : MonoBehaviour
{
    Button button;
    AudioSource clickAudio;

    void Start()
    {
        button = GetComponent<Button>();
        clickAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (button != null && collision.gameObject.CompareTag("Hand"))
        {
            clickAudio.Play();
            button.onClick.Invoke();
            return;
        }
    }
}