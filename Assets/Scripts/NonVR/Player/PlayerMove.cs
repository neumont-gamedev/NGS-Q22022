using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public CharacterController controller;
    public float Speed = 5f;
    private Vector3 velocity;

    public GameObject Shovel;
    public GameObject Pickaxe;
    public GameObject Drill;

    public float jump = 10f;
    public float Gravity = -9.8f;

    public string curTool = "Shovel";


    private void Start()
    {
        Shovel.SetActive(true);
        Pickaxe.SetActive(false);
        Drill.SetActive(false);
    }
    void Update()
    {

        // for movement
        float horizontal = Input.GetAxis("Horizontal") * Speed;
        float vertical = Input.GetAxis("Vertical") * Speed;
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move * Speed * Time.deltaTime);
        // for jump
        if (Input.GetKeyDown(KeyCode.Space))// && transform.position.y < -0.51f)
        // (-0.5) change this value according to your character y position + 1
        {
            Debug.Log("Jump");
            velocity.y = jump;
        }
        else
        {
            velocity.y += Gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);

        //Move();
        //ChooseTool();
        //Gravity();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Shovel.SetActive(true);
            Pickaxe.SetActive(false);
            Drill.SetActive(false);
            curTool = "Shovel";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Shovel.SetActive(false);
            Pickaxe.SetActive(true);
            Drill.SetActive(false);
            curTool = "Pickaxe";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Shovel.SetActive(false);
            Pickaxe.SetActive(false);
            Drill.SetActive(true);
            curTool = "Hammer";
        }

    }
}

        //Vector3 direction = Vector3.zero;
        //direction.x = Input.GetAxis("Horizontal");
        //direction.z = Input.GetAxis("Vertical");

        //Vector3 velocity = direction * speed;
        //transform.position += velocity * Time.deltaTime;

    //}

    //void Gravity()
    //{
    //    Vector3 gravity = new Vector3(0, controller.isGrounded ? 0 : -2, 0);
    //    controller.Move(gravity);
    //}

//    void Move()
//    {
//        float x = Input.GetAxis("Horizontal");
//        float z = Input.GetAxis("Vertical");

//        Vector3 move = transform.right * x + transform.forward * z;

//        controller.Move(move * speed * Time.deltaTime);

//        if (Input.GetButtonDown("Jump") && transform.position.y < -0.51f)
//        // (-0.5) change this value according to your character y position + 1
//        {
//            velocity.y = jump;
//        }
//        else
//        {
//            velocity.y += Gravity * Time.deltaTime;
//        }
//        controller.Move(velocity * Time.deltaTime);
//    }
//}

/*    public string ChooseTool()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Shovel.SetActive(true);
            Pickaxe.SetActive(false);
            Drill.SetActive(false);
            curTool = "Shovel";
            return curTool;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Shovel.SetActive(false);
            Pickaxe.SetActive(true);
            Drill.SetActive(false);
            curTool = "Pickaxe";
            return curTool;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Shovel.SetActive(false);
            Pickaxe.SetActive(false);
            Drill.SetActive(true);
            curTool = "Drill";
            return curTool;
        }

        return curTool;
    }
*/


