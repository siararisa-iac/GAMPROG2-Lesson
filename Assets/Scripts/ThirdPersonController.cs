using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    //serialize field makes the variable appear in inspector without //having to make it private
    [SerializeField] float rotationSmoothTime = 0.01f;
    float currentAngle;
    float currentAngleVelocity;

    CharacterController controller;
    Camera cam;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
    }
   
    private void Update()
    {
        HandleMovement();
    }

    // Entire movement code encapsulated in a function
    // and calling it from Update
    private void HandleMovement()
    {
        //capturing Input from Player
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        if (movement.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            currentAngle = Mathf.SmoothDampAngle(currentAngle, targetAngle, ref currentAngleVelocity, rotationSmoothTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);
            Vector3 rotatedMovement = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(rotatedMovement * speed * Time.deltaTime);
        }
    }

}
