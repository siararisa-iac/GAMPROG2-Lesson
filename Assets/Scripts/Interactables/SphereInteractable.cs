using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereInteractable : Interactable
{
    // Make the sphere move to the right whenever interacted
    public override void Interact()
    {
        transform.position += Vector3.right * 0.25f;
    }
}
