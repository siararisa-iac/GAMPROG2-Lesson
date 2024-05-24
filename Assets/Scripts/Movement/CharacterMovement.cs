using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 2.0f;

    private CharacterController controller;
    private float gravity = -9.8f;

    private void Awake()
    {
        // Get the reference to the attached character controller Component
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float xMovement = Input.GetAxisRaw("Horizontal"); // value will return either 1 or 0 or -1
        float zMovement = Input.GetAxis("Vertical"); //value will return a range from 0 to -1 or 0 to 1

        // Create a vector3 that will store the direction of our movement
        // Use transform.right instead of Vector3.right so we can take into account the local orientation of the player
        Vector3 moveDirection = (transform.right * xMovement) + (transform.forward * zMovement);
        // Add gravity
        moveDirection.y += gravity;
        moveDirection *= moveSpeed * Time.deltaTime;
        controller.Move(moveDirection);
    }
}
