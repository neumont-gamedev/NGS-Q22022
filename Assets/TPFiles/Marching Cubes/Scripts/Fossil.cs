using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Fossil : MonoBehaviour
{
    public bool cleaned = false;
    public AudioClip[] clips;
    private UIManager uiBoi;

    private void Awake()
    {
        uiBoi = FindObjectOfType<UIManager>();
        ani = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        shell = transform.Find("Shell").gameObject;
        shell.SetActive(false);
        name = name.Replace("(Clone)", "");
    }

    //Checks if the fossil is being dug up
    //And when the diffing is finished
    #region digging
    private bool unburied = false;
    private bool buried = true;
    private bool startDigging = false;

    private void FixedUpdate()
    {
        if (startDigging)
        {
            if (!buried)
            {
                unburied = true;
                if (!foundAudioPlayed)
                {
                    uiBoi.DiggingObjective(2);
                    foundAudioPlayed = true;
                    audioSource.clip = clips[0];
                    audioSource.Play();
                }
            }
            if (!unburied)
            {
                buried = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!startDigging)
            {
                startDigging = true;
                uiBoi.DiggingObjective(1);
            }
            if (!unburied)
            {
                buried = true;
            }
        }

        else if (collision.gameObject.CompareTag("Plaster"))
        {
            if (plastered) return;
            Debug.LogWarning("Plastered");
            Plaster();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //Checks if it  is still buried
        if (collision.gameObject.CompareTag("Ground") && !unburied)
        {
            buried = true;
        }
        //Checks for plastering 
        else if (collision.gameObject.CompareTag("Plaster") && unburied)
        {
            if (plastered) return;
            Plaster();
        }
    }
    #endregion

    //Plasters fossil
    #region plaster
    private bool plastered = false;
    private bool foundAudioPlayed = false;
    private AudioSource audioSource;
    private OVRGrabbable grabbable;
    private Animator ani;
    private GameObject shell;

    public void Plaster()
    {
        plastered = true;
        shell.SetActive(true);
        ani.Play("FieldJacketClose");
    }

    
    public void PlasterDry()
    {
        var renderers = shell.GetComponentsInChildren<MeshRenderer>();
        foreach (var r in renderers)
        {
            StartCoroutine(PlasterDryCo(r));
        }
    }

    private IEnumerator PlasterDryCo(MeshRenderer r, float timer = 0.5f)
    {
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            float t = 1.0f - (timer / 0.5f);
            r.materials[1].color = Color.Lerp(Color.clear, Color.white, t);

            yield return null;
        }

        r.materials = new Material[1] { r.materials[1] };

        yield return true;
    }

    public void PlasterDone()
    {
        grabbable = gameObject.AddComponent<OVRGrabbable>();
        grabbable.enabled = true;
        grabbable.allowOffhandGrab = true;
        grabbable.snapPosition = true;
        grabbable.snapOrientation = true;
        grabbable.snapOffset = gameObject.transform.Find("Offset");
        grabbable.grabPoints[0] = grabbable.snapOffset.gameObject.GetComponent<Collider>();

        audioSource.clip = clips[1];
        audioSource.Play();
        uiBoi.DiggingObjective(3);
        StartCoroutine(PlasterBackpack(2));
    }

    private IEnumerator PlasterBackpack(float timer = 1f)
    {
        yield return new WaitForSeconds(timer);

        FossilHolder.AddToBackpack(name);
        Destroy(this.gameObject);
        
        yield return true;
    }
    #endregion
}
