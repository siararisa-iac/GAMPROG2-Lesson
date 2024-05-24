using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : Interactable
{
    // Increase the scale whenever we interact with the cube
    public override void Interact()
    {
        transform.localScale += Vector3.one * 0.25f;
    }
}
