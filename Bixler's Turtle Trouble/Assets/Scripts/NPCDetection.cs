using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDetection : MonoBehaviour
{
    public Transform detectionOrigin; // Reference to the detection origin game object on the NPC
    public float detectionRange = 10f; // The range of detection
    public float detectionAngle = 60f; // The angle of detection in degrees
    public float detectionRadius = 1f; // The radius of the detection sphere
    public string targetObjectName = "turtle"; // The name of the target game object

    void Update()
    {
        // Calculate the half angle in radians
        float halfAngle = Mathf.Deg2Rad * detectionAngle * 0.5f;

        // Calculate the forward and right vectors of the detection origin
        Vector3 forward = detectionOrigin.forward;
        Vector3 right = detectionOrigin.right;

        // Calculate the start position of the detection sphere
        Vector3 startPosition = detectionOrigin.position + forward * detectionRadius;

        // Cast multiple overlapping spheres in a cone
        RaycastHit[] hits = Physics.SphereCastAll(startPosition, detectionRadius, forward, detectionRange);

        foreach (RaycastHit hit in hits)
        {
            if (Vector3.Dot((hit.point - detectionOrigin.position).normalized, forward) > Mathf.Cos(halfAngle))
            {
                if (hit.collider.CompareTag(targetObjectName))
                {
                    // The NPC is looking at the target game object
                    Debug.Log("NPC is looking at " + targetObjectName);
                    // You can put your desired logic here, such as triggering an event or changing NPC behavior
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a sphere representing the detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(detectionOrigin.position, detectionRange);
    }
}