using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameButton : MonoBehaviour
{
    [SerializeField] AudioSource clickAudio;
    Button button;

    void Start()
    {
        button = GetComponent<Button>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (button != null && collision.gameObject.CompareTag("Hand"))
        {
            if(clickAudio != null)
            {
                AudioSource.PlayClipAtPoint(clickAudio.clip, transform.position);
                //clickAudio.Play();
                button.onClick.Invoke();
                return;
            }
            
        }
    }
}