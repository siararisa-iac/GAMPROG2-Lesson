using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;
    [SerializeField]
    private LayerMask interactionLayer;
    [SerializeField]
    private Image crosshair;

    private void Start()
    {
        // Ensure the cursor stays in the middle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        //bool didPress = isHorizontalInputPressed(out float input);
        //Debug.Log($"Did press {didPress}. The input value is {input}");

        // Store the information of what the raycast has hit
        //RaycastHit hit;
        // Perform a raycast that start at the position of the player, and shoots forward at the specified raycastDistance
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, raycastDistance, interactionLayer))
        {
            // Print out whatever the raycast hits
            Debug.Log(hit.collider.gameObject.name);
            crosshair.color = Color.red;
            crosshair.transform.localScale = Vector3.one * 1.10f;
            // Detect whenever the left mouse button is pressed or clicked
            if (Input.GetMouseButtonDown(0))
            {
                // Do something with the object hit
                // Does the hit gameobject have any Interactable component?
                // Null check
                if(hit.collider.gameObject.GetComponent<Interactable>() != null)
                {
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                }
            }
        }
        else
        {
            //Raycast did not hit anything
            crosshair.color = Color.white;
            crosshair.transform.localScale = Vector3.one;
        }

        // Visualize the raycast
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.red);
    }

    private bool isHorizontalInputPressed(out float inputValue)
    {
        inputValue = Input.GetAxis("Horizontal");
        return inputValue != 0;
    }
}
