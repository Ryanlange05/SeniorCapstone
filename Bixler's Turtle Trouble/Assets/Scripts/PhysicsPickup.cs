using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    [SerializeField] private LayerMask pickupMask; // Determines what layer the player is able to pick up
    [SerializeField] private Camera playerCamera; // Allows function viewport point to ray
    [SerializeField] private Transform pickupTarget;
    [Space]
    [SerializeField] private float pickupRange;
    private Rigidbody currentObject;
    public bool isHoldingObject = false;
    public Rigidbody counterTurt;
    int isSpawned = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingObject)
            {
                ReleaseObject();

                // Play audio
                FindObjectOfType<SAudioManager>().Play("pop");

                if (!currentObject.useGravity)
                {
                    FindObjectOfType<CountDown>().startTimer();
                    Debug.Log("Starting Timer");
                    if (isSpawned == 0)
                    {
                        FindObjectOfType<RandomSpawner1>().spawnTurts();
                        isSpawned++;
                        Debug.Log("Spawning Turts");
                    }
                }
            }
            else
            {
                PickUpObject();
            }
        }
    }

    void FixedUpdate()
    {
        if (isHoldingObject)
        {
            Vector3 directionToPoint = pickupTarget.position - currentObject.position;
            float distanceToPoint = directionToPoint.magnitude;

            currentObject.velocity = directionToPoint * 6f * distanceToPoint;
        }
    }

    public void PickUpObject()
    {
        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo, pickupRange, pickupMask))
        {
            // Play audio
            FindObjectOfType<SAudioManager>().Play("pop");

            currentObject = hitInfo.rigidbody;
            currentObject.useGravity = false;
            isHoldingObject = true;
        }
    }

    public void ReleaseObject()
    {
        currentObject.useGravity = true;
        currentObject = null;
        isHoldingObject = false;
    }
}