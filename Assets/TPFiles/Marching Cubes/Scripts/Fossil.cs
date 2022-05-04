using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fossil : MonoBehaviour
{
    //public Material setJacketMaterial;

    private bool unburied = false;
    private bool buried = true;
    private bool startDigging = false;
    private bool plastered = false;
    public bool cleaned = false;
    public string Name;

    private OVRGrabbable grabbable;
    private Animator ani;
    private GameObject shell;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        shell = transform.Find("Shell").gameObject;
        shell.SetActive(false);
        name = name.Replace("(Clone)", "");
        this.Name = name;
    }

    //resets buried to false until it comes back false
    private void FixedUpdate()
    {
        if (startDigging)
        {
            if (!buried)
            {
                unburied = true;
            }
            if (!unburied)
            {
                buried = false;
            }
        }
    }

    //starts the digging and sets buried true
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!startDigging)
            {
                startDigging = true;
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

    //changes buried true as long as they collide
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Ground") && !unburied)
        {
            buried = true;
        }
        else if (collision.gameObject.CompareTag("Plaster") && unburied)
        {
            if (plastered) return;
            Debug.LogWarning("Plastered");
            Plaster();
        }
    }

    public void Clean() { cleaned = true; }
    public bool isFound() { return cleaned; }

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

        StartCoroutine(PlasterBackpack(2));
    }

    private IEnumerator PlasterBackpack(float timer = 1f)
    {
        yield return new WaitForSeconds(timer);

        Fossil nFossil = this;
        if(nFossil != null)
        {
            FossilHolder.AddToBackpack(nFossil);
            Destroy(this.gameObject);
        }
        yield return true;
    }

}
