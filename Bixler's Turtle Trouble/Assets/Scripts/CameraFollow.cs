using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform characterHead;
    public Vector3 rotationOffset;

    private Quaternion initialRotation;

    private void Start()
    {
        // Store the initial rotation of the PlayerCameraRoot
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        if (characterHead != null)
        {
            // Set the PlayerCameraRoot's position to match the character's head
            transform.position = characterHead.position;

            // Calculate the target rotation based on the initial rotation and mouse movement
            Quaternion targetRotation = initialRotation * Quaternion.Euler(rotationOffset.x, 0f, rotationOffset.z);
            
            // Apply the target rotation only on the Y-axis
            Vector3 targetEulerAngles = targetRotation.eulerAngles;
            targetEulerAngles.x = 0f;
            targetEulerAngles.z = 0f;
            targetRotation = Quaternion.Euler(targetEulerAngles);

            // Smoothly interpolate the rotation to avoid sudden jumps
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }
}


