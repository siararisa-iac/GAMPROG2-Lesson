using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField]
    private Camera camera;

    [SerializeField]
    private float moveSpeed = 2.0f;
    
    private CharacterController controller;
    private float gravity = -9.8f;

    private float currentSpeed;
    private void Awake()
    {
        // Get the reference to the attached character controller Component
        controller = GetComponent<CharacterController>();
        // automatically set up reference to the camera to avoid null reference error
        if(camera == null)
        {
            camera = Camera.main;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movementInput = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        // Later on, apply a sprinting speed
        currentSpeed = moveSpeed;

        // Make the player move
        if(movementInput.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movementInput.x, movementInput.z) * Mathf.Rad2Deg;
            //Debug.Log($"target angle is {targetAngle}");
            //Change the rotation angle of the player
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            controller.Move(movementInput * currentSpeed * Time.deltaTime);
        }
    }
}
