using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 offset;
    private float rotationX, rotationY;
    private Quaternion initialRotation;
    [SerializeField]
    private float headRotationLimit = 60f;

    // Start is called before the first frame update
    void Start()
    {
        //Make sure the cursor stays in the center of the screen
        //Change the lock state of our cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Save the initial rotation of the camera in the Editor Scene view
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    private void Update()
    {
        //look up and down is based on the x-axis rotation
        rotationX += Input.GetAxis("Mouse Y");
        //look left and right is based on the y-axis rotation
        rotationY += Input.GetAxis("Mouse X");

        //Limit the value of our lookup/down based on the head rotation value
        rotationX = Mathf.Clamp(rotationX, -headRotationLimit, headRotationLimit);
    }

    private void LateUpdate()
    {
        //rotate the camera to face our mouse direction
        Quaternion rotation = Quaternion.Euler(-rotationX, rotationY, 0);
        //add the initial rotation to the final rotation
        Quaternion finalRotation = initialRotation * rotation;
        transform.rotation = finalRotation;

        //make the camera follow the target
        // transform.position = target.transform.position + offset;
        //rotate the target to face the camera direction
        target.transform.rotation = Quaternion.Euler(
            target.transform.rotation.x,
            finalRotation.eulerAngles.y,
            target.transform.rotation.z);
    }
}
