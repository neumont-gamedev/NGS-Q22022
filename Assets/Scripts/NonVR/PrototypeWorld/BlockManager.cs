using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    public enum RockType
    {
        NONE,
        DIRT,
        MUD,
        STONE,
        STONE2
    }

    //string objectType;

    public RockType currentType;
    public float health;
    public string[] tagNames = { "Spoon", "Shovel", "Pickaxe", "Hammer"};

    void Start()
    {

        switch (currentType)
        {
            case RockType.DIRT:
                health = 2;
                break;
            case RockType.MUD:
                health = 4;
                break;
            case RockType.STONE:
                health = 6;
                break;
            case RockType.STONE2:
                health = 10;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void DestroyMaterial()
    {
        if(health <= 0)
        {
            if (this.GetComponent<Spawner>())
            {
                this.GetComponent<Spawner>().SpawnBone();
                Destroy(gameObject);
                Debug.Log("Destroy and Spawn bone");
            }
            else
            {
            Destroy(gameObject);
            Debug.Log("Destroyed");

            }
        }
        else
        {
            Debug.Log(health);
        }
    }

    public void collisionHandler(RockType blockType, string objectType)
    {
        switch (blockType)
        {
            case RockType.NONE:
                break;
            case RockType.DIRT:
                if(objectType == "Spoon")
                {
                    health -= 1;
                    Debug.Log("Spoon");
                }
                else if (objectType == "Shovel")
                {
                    health -= 3;
                    Debug.Log("Shovel");
                }
                else if (objectType == "Pickaxe")
                {
                    health -= 0.5f;
                    Debug.Log("Pickaxe");
                }
                else if (objectType == "Hammer")
                {
                    health -= 0.2f;
                    Debug.Log("Hammer");
                }
                break;
            case RockType.MUD:
                if (objectType == "Spoon")
                {
                    health -= 0.5f;
                    Debug.Log("Spoon");
                }
                else if (objectType == "Shovel")
                {
                    health -= 3;
                    Debug.Log("Shovel");
                }
                else if (objectType == "Pickaxe")
                {
                    health -= 0f;
                    Debug.Log("Pickaxe");
                }
                else if (objectType == "Hammer")
                {
                    health -= 0f;
                    Debug.Log("Hammer");
                }
                break;
            case RockType.STONE:
                if (objectType == "Spoon")
                {
                    health -= 0.1f;
                    Debug.Log("Spoon");
                }
                else if (objectType == "Shovel")
                {
                    health -= 0.5f;
                    Debug.Log("Shovel");
                }
                else if (objectType == "Pickaxe")
                {
                    health -= 2;
                    Debug.Log("Pickaxe");
                }
                else if (objectType == "Hammer")
                {
                    health -= 1f;
                    Debug.Log("Hammer");
                }
                break;
            case RockType.STONE2:
                if (objectType == "Spoon")
                {
                    health -= 0;
                    Debug.Log("Spoon");
                }
                else if (objectType == "Shovel")
                {
                    health -= 0;
                    Debug.Log("Shovel");
                }
                else if (objectType == "Pickaxe")
                {
                    health -= 0.5f;
                    Debug.Log("Pickaxe");
                }
                else if (objectType == "Hammer")
                {
                    health -= 2f;
                    Debug.Log("Hammer");
                }
                break;
            default:
                break;
        }
    }
}
