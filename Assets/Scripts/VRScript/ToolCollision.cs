using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCollision : MonoBehaviour
{

    public AudioSource digNoise;
    public World world;
    BlockType current;
    public DinoBlockManager dinoStoneCheck;

    private void Awake()
    {
        world = FindObjectOfType<World>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public string OnCollisionEnter(Collision collision)
    {

        ChunkRenderer chunk = collision.gameObject.GetComponent<ChunkRenderer>();
       

        if (chunk != null)
        {
            Debug.Log("Chunk hit.");
            Vector3Int pos = world.GetBlockPosCollision(collision);
            current = world.GetBlockFromChunkCoordinates(chunk.ChunkData, pos.x, pos.y, pos.z);
            Debug.Log(current.ToString());

            switch (current.ToString())
            {

                case "":
                    break;
                case "DinoStone":
                    Debug.Log("Dino_Stone Struck");
                    digNoise.Play();
                    dinoStoneCheck.RanSpawn(collision.transform.position);
                    break;

            }

            ModifyTerrain(collision);

            return current.ToString();
        }


            

        return "";
    }

    private void ModifyTerrain(Collision collision)
    {
        world.SetBlockCollision(collision, BlockType.Air);
        Debug.Log("Set block");
    }

    //CheckCollision(collision);
    //Ray playerRay = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
    //RaycastHit hit;
    //string rayblock;

    //if (Physics.Raycast(playerRay, out hit, interactionRayLength, groundMask))
    //{
    //    Vector3 hitpoint = hit.point;

    //    rayblock = CheckRay();

    //    switch (rayblock)
    //    {

    //        case "":
    //            break;
    //        case "DinoStone":
    //            Debug.Log("Dino_Stone Struck");

    //            dinoStoneCheck.RanSpawn(hitpoint);
    //            break;

    //    }

    //    ModifyTerrain(hit);
    //}

}

