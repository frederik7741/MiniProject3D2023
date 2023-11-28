using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Reference to the target camera position
    public Transform cameraPosition;

    private void Update()
    {
        // Update the position of the object to match the camera position
        transform.position = cameraPosition.position;
    }
}

