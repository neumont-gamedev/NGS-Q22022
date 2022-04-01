using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCollision : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public World world;

    public float interactionRayLength = 5;

    public LayerMask groundMask;

    Ray playerRay;
    //RaycastHit hit;
    public string blockName;

    //public DinoBlockManager dinoStoneCheck;

    //take logic and instead make based off a collider
    private void Awake()
    {
        world = FindObjectOfType<World>();
    }

    

    //public string CheckCollision(Vecto)
    //{
    //    BlockType current;
    //    playerRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

    //    //if (Physics.Raycast(playerRay, out hit, interactionRayLength, groundMask))//Check for a collision
    //    if()//check for physical collision
    //    {

    //        ChunkRenderer chunk = hit.collider.GetComponent<ChunkRenderer>();
    //        if (chunk == null)
    //        {
    //            Debug.Log("No Chunk");
    //        }
    //        else
    //        {
    //            Debug.Log("There's a Chunk");
    //            Debug.Log(chunk.ChunkData.blocks.Length);
    //            Vector3Int pos = world.GetBlockPos(hit);

    //            current = world.GetBlockFromChunkCoordinates(chunk.ChunkData, pos.x, pos.y, pos.z);
    //            Debug.Log(current.ToString());
    //            return current.ToString();
    //        }
    //    }
    //    return "";
    //}

    private void ModifyTerrain(RaycastHit hit)
    {
        world.SetBlock(hit, BlockType.Air);
    }


    /*    private void HandleMouseClick()
        {
            Ray playerRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            //RaycastHit hit;
            string rayblock;


            if (Physics.Raycast(playerRay, out hit, interactionRayLength, groundMask))
            {
                Vector3 hitpoint = hit.point;

                rayblock = CheckRay();

                switch (rayblock)
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

        }*/
}
