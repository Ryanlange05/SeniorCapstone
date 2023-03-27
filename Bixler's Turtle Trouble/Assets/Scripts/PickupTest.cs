using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTest : MonoBehaviour
{
    public float pickupDistance = 1f; // The maximum distance at which an object can be picked up
    public float throwForce = 10f; // The force at which an object is thrown when released

    private GameObject heldObject; // The object that is currently being held
    private Rigidbody heldObjectRb; // The rigidbody of the held object
    private Vector3 heldObjectOffset; // The offset between the held object and the mouse position

    void Update()
    {
        // If the "e" key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cast a ray from the player position and check if it hits a rigidbody
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, pickupDistance) && hit.rigidbody)
            {
                // Pick up the object if it's not already being held
                if (!heldObject)
                {
                    heldObject = hit.collider.gameObject;
                    heldObjectRb = heldObject.GetComponent<Rigidbody>();
                    heldObjectOffset = heldObject.transform.position - hit.point;
                    heldObjectRb.isKinematic = true;
                }
            }
        }

        // If the "e" key is released
        if (Input.GetKeyUp(KeyCode.E))
        {
            // Release the held object
            if (heldObject && heldObjectRb)
            {
                heldObjectRb.isKinematic = false;
                heldObjectRb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
                heldObject = null;
                heldObjectRb = null;
            }
        }

        // If an object is being held
        if (heldObject)
        {
            // Move the object to the player position
            Vector3 targetPosition = transform.position + transform.forward * heldObjectOffset.magnitude;
            heldObjectRb.MovePosition(targetPosition + heldObjectOffset);
        }
    }
}