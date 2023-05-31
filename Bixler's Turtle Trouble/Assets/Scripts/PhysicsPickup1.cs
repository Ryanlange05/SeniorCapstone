using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup1 : MonoBehaviour
{
    [SerializeField] private LayerMask pickupMask; // Determines what layer the player is able to pick up
    [SerializeField] private Camera playerCamera; // Allows function viewport point to ray
    [SerializeField] private Transform pickupTarget;
    [Space]
    [SerializeField] private float pickupRange;
    private Rigidbody currentObject;
    public bool isHoldingObject = false;
  //  int isSpawned = 0;
  // int isTimed = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isHoldingObject)
            {
                ReleaseObject();

                // Play audio
                FindObjectOfType<SAudioManager>().Play("pop");
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


            //neccessary stuff
            currentObject = hitInfo.rigidbody;
            currentObject.useGravity = false;
            isHoldingObject = true;

            //for starting the timer

            /*if (!currentObject.useGravity)
            {
                if (isTimed == 0 && currentObject.CompareTag("Turtle"))
                {
                    FindObjectOfType<CountDown>().startTimer();
                    Debug.Log("Starting Timer");
                    isTimed++;
                }
            }
            */


        }
    }

    public void ReleaseObject()
    {
        currentObject.useGravity = true;
        currentObject = null;
        isHoldingObject = false;
    }
}