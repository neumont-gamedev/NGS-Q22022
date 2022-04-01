using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{

    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private PlayerMovement playerMovement;

    public float interactionRayLength = 5;

    public LayerMask groundMask;

    //public RegPlayerMove playerMovement;

    public World world;


    // Start is called before the first frame update

    private void Awake()
    {
        world = FindObjectOfType<World>();
    }

    void Start()
    {
        //playerMovement.OnMouseClick += HandleMouseClick;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HandleMouseClick()
    {
        Ray playerRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(playerRay, out hit, interactionRayLength, groundMask))
        {
            ModifyTerrain(hit);
        }

    }

    private void ModifyTerrain(RaycastHit hit)
    {
        world.SetBlock(hit, BlockType.Air);
    }


}
