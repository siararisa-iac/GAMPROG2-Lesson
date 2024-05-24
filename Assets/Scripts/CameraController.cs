using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float headRotationLimit = 60.0f;

    private float rotationY, rotationX;

    private void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        GetInput();
    }

    private void LateUpdate()
    {
        // We make changes to our camera's position and rotation inside the LateUpdate to ensure that our target's position
        // has already been updated before we change / update the camera

        // Limit the x axis rotation so we do not overlook
        rotationX = Mathf.Clamp(rotationX, -headRotationLimit, headRotationLimit);

        // Rotate the camera to face our mouse direction
        Quaternion rotation = Quaternion.Euler(-rotationX, rotationY, 0);
        // Set the rotation of our own transform to the eulerAngles rotation
        transform.rotation = rotation;

        FollowTarget();
    }
    private void GetInput()
    {
        // Get the mouse movement 
        // look up and down with mouse is based on the x-axis rotation
        rotationX += Input.GetAxis("Mouse Y");
        // look left and right is based on the y-axis rotation
        rotationY += Input.GetAxis("Mouse X");
    }

    private void FollowTarget()
    {
        // Make the camera follow the target
        transform.position = target.transform.position;
        // Orient our target to face where the camera is facing
        target.transform.rotation = Quaternion.Euler(
            target.transform.rotation.x,
            rotationY, // The y-axis rotation (where the left and right look is should be the same as that of the camera)
            target.transform.rotation.z);
    }
    
}
