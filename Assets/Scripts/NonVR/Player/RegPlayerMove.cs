using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegPlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float Speed = 5f;
    private Vector3 velocity;
    public float jump = 10f;
    public float Gravity = -9.8f;

    public event Action OnMouseClick;
    public Vector2 MousePosition { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

    }

    private void GetMousePosition()
    {
        MousePosition = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseClick?.Invoke();

        }
    }

}
