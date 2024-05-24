using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float moveSpeed = 2.0f;

    // Store the input from the user
    private float xMovement, zMovement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Get the input from the user in the Update function
    private void Update()
    {
        xMovement = Input.GetAxis("Horizontal");
        zMovement = Input.GetAxis("Vertical");
        // Detect if the user presses the spacebar
    }

    // Where all physics calculations should be
    private void FixedUpdate()
    {
        // Change the velocity based on the movement input
        Vector3 movement = (transform.right * xMovement) + (transform.forward * zMovement);
        rb.velocity = movement * moveSpeed;
        // Add force whenever there's jump detected
    }
}
