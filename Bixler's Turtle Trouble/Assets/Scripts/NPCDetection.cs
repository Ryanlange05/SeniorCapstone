using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class NPCDetection : MonoBehaviour
{
    public LayerMask targetLayer;
    public float detectionRange = 10f;
    public float fieldOfViewAngle = 60f;
    public float maxAngle = 180f;

    void Update()
    {
        DetectTarget();
    }

    void DetectTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, detectionRange, targetLayer);
        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 targetDirection = targets[i].transform.position - transform.position;
            float angle = Vector3.Angle(targetDirection, transform.forward);
            if (angle <= fieldOfViewAngle * 0.5f && angle <= maxAngle * 0.5f)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, targetDirection, out hit, detectionRange))
                {
                    if (hit.collider.gameObject.CompareTag("Turtle"))
                    {
                        Debug.Log("Turtle detected!");
                    }
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Update the position and rotation of the vision cone to match the NPC's position and rotation
        Matrix4x4 originalMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(Vector3.zero, detectionRange);

        Vector3 frontRayDirection = Quaternion.Euler(0, -fieldOfViewAngle * 0.5f, 0) * transform.forward;
        Vector3 rightRayDirection = Quaternion.Euler(0, fieldOfViewAngle * 0.5f, 0) * transform.forward;

        Gizmos.DrawRay(Vector3.zero, frontRayDirection * detectionRange);
        Gizmos.DrawRay(Vector3.zero, rightRayDirection * detectionRange);

        Gizmos.DrawFrustum(Vector3.zero, fieldOfViewAngle, detectionRange, 0f, 1f);

        Gizmos.matrix = originalMatrix;
    }
}