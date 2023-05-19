using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;
    [SerializeField]
    private Transform origin;
    [SerializeField]
    private Transform text;
    [SerializeField]
    private Camera camera;
    [SerializeField]
    LayerMask layerMask;

    private void Update()
    {
        //Perform a raycast
        RaycastHit hit;
        Vector3 rayDirection = (transform.forward).normalized;
        /*
        //if the raycast hits an object
        if (Physics.Raycast(origin.position, rayDirection, out hit, raycastDistance, layerMask))
        {
            //do something
            Debug.Log("Raycast hits " + hit.collider.gameObject.name);
            // Convert the world position to screen space
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(hit.point);
            text.gameObject.SetActive(true);
            // Set the UI element's position based on the screen position
            text.position = screenPosition;
            //if we press the mouse button to interact,
            if (Input.GetMouseButtonDown(0))
            {
                //interact with the object if it is an interactable
                if(hit.collider.gameObject.GetComponent<Interactable>() != null)
                {
                    //call the interact function of the interactable class
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                }
            }
        }
        else
        {
            text.gameObject.SetActive(false);
        }
        */

        if(Physics.SphereCast(origin.position, 3.0f, rayDirection, out hit, raycastDistance))
        {
            //do something
            Debug.Log("Raycast hits " + hit.collider.gameObject.name);
            // Convert the world position to screen space
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(hit.point);
            text.gameObject.SetActive(true);
            // Set the UI element's position based on the screen position
            text.position = screenPosition;
            //if we press the mouse button to interact,
            if (Input.GetMouseButtonDown(0))
            {
                //interact with the object if it is an interactable
                if (hit.collider.gameObject.GetComponent<Interactable>() != null)
                {
                    //call the interact function of the interactable class
                    hit.collider.gameObject.GetComponent<Interactable>().Interact();
                }
            }
        }
        else
        {
            text.gameObject.SetActive(false);
        }

        //visualize the raycast
        Debug.DrawRay(origin.position, rayDirection * raycastDistance, Color.red);
    }
}
