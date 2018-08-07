using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject weapon;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(inputH, 0, inputV);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        // Check if space is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Run hit sequence
            weapon.SetActive(true);
        }
    }
}
