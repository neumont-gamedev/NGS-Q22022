using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private PlayerMovement playerMovement;

    public float interactionRayLength = 5;

    public LayerMask groundMask;

    public bool fly = false;

    public Animator animator;

    bool isWaiting = false;

    public World world;

    Ray playerRay;
    RaycastHit hit;
    public string blockName;

    public DinoBlockManager dinoStoneCheck;

    public float jump = 10f;
    public float Gravity = -9.8f;

    public string curTool;




    private void Awake()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
        world = FindObjectOfType<World>();
    }

    private void Start()
    {
        playerInput.OnMouseClick += HandleMouseClick;
        playerInput.OnFly += HandleFlyClick;
        DinoBlockManager dinoStoneCheck = gameObject.GetComponent<DinoBlockManager>();
    }

    private void HandleFlyClick()
    {
        fly = !fly;
    }

    void Update()
    {

        //CheckRay();
        if (fly)
        {
            animator.SetFloat("speed", 0);
            animator.SetBool("isGrounded", false);
            animator.ResetTrigger("jump");
            playerMovement.Fly(playerInput.MovementInput, playerInput.IsJumping, playerInput.RunningPressed);
        }
        else
        {
            animator.SetBool("isGrounded", playerMovement.IsGrounded);
            if (playerMovement.IsGrounded && playerInput.IsJumping && isWaiting == false)
            {
                animator.SetTrigger("jump");
                isWaiting = true;
                StopAllCoroutines();
                StartCoroutine(ResetWaiting());
            }
            animator.SetFloat("speed", playerInput.MovementInput.magnitude);
            playerMovement.HandleGravity(playerInput.IsJumping);
            playerMovement.Walk(playerInput.MovementInput, playerInput.RunningPressed);
        }

    }
    IEnumerator ResetWaiting()
    {
        yield return new WaitForSeconds(0.1f);
        animator.ResetTrigger("jump");
        isWaiting = false;
    }


    //take logic and instead make based off a collider
    private void HandleMouseClick()
    {
        Ray playerRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        //RaycastHit hit;
        string rayblock;


        if (Physics.Raycast(playerRay, out hit, interactionRayLength, groundMask))
        {
            Vector3 hitpoint = hit.point;

            rayblock = CheckRay();

            switch(rayblock)
            {

                case "":
                    break;
                case "DinoStone":
                    Debug.Log("Dino_Stone Struck");

                    dinoStoneCheck.RanSpawn(hitpoint);
                    break;

            }

            ModifyTerrain(hit);
        }

    }

    //Nothing,
    //Air,
    //Grass_Dirt,
    //Dirt,
    //Grass_Stone,
    //Stone,
    //TreeTrunk,
    //TreeLeafesTransparent,
    //TreeLeafsSolid,
    //Water,
    //Sand,
    //DinoStone

    private void ModifyTerrain(RaycastHit hit)
    {
        world.SetBlock(hit, BlockType.Air);
    }

    public string CheckRay()
    {
        BlockType current;
        playerRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

        //RaycastHit hit;
        if (Physics.Raycast(playerRay, out hit, interactionRayLength, groundMask))//Physics.Raycast(playerRay, out hit, 100))
        {

            ChunkRenderer chunk = hit.collider.GetComponent<ChunkRenderer>();
            if (chunk == null)
            {
                Debug.Log("No Chunk");
            }
            else
            {

                Debug.Log("There's a Chunk");
                Debug.Log(chunk.ChunkData.blocks.Length);
                Vector3Int pos = world.GetBlockPos(hit);

                current = world.GetBlockFromChunkCoordinates(chunk.ChunkData, pos.x, pos.y, pos.z);
                Debug.Log(current.ToString());
                return current.ToString();
            }
        }
        return "";
    }

}