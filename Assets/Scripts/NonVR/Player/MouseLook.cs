using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BlockManager;

public class MouseLook : MonoBehaviour
{
    // Start is called before the first frame update

    public float lookSpeed = 100f;

    public Vector3 rCollision = Vector3.zero;
    public Transform playerTransform;

    float xRotation = 0f;

    public GameObject player;
    public string currentObject; // shovel
    GameObject lastHit;
    RockType objectEnum;

    //public Transform playerSpine;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        var ray = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(ray, out hit, 100))
        {

            rCollision = hit.point;
            if(hit.collider.transform.tag != "Untagged")
            {
                lastHit = hit.collider.transform.gameObject;
                //Debug.Log(hit.collider.transform.tag);
                RayHitManager(hit.collider.transform.tag, hit.transform.gameObject);

                if(Input.GetMouseButtonDown(0))
                {
                    currentObject = player.GetComponent<PlayerMove>().curTool;
                    HitBlock();
                }

            }
            //Debug.Log(hit.collider.transform.tag);
        }

        float mouseX = Input.GetAxis("Mouse X") * lookSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerTransform.Rotate(Vector3.up * mouseX);

    }

    private void OnDrawGizmos()
    {
        Update();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rCollision, 0.2f);
    }

    private void RayHitManager(string tag, GameObject objectHit)
    {
        if (tag.Equals("Block"))
        {
            Debug.Log(tag);
           objectEnum = objectHit.GetComponent<BlockManager>().currentType;
           Debug.Log(objectHit.GetComponent<BlockManager>().currentType.ToString());
            
           //Debug.Log(player.GetComponent<PlayerMove>().curTool);
           //currentObject = player.GetComponent<PlayerMove>().curTool;
        }

    }

    private void HitBlock()
    {
        lastHit.GetComponent<BlockManager>().collisionHandler(objectEnum, currentObject);
        lastHit.GetComponent<BlockManager>().DestroyMaterial();
    }

}


