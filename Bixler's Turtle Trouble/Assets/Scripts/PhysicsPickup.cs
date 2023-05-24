using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{
    
    [SerializeField] private LayerMask PickupMask; // Determines what layer the player is able to pick up
    [SerializeField] private Camera PlayerCamera; // Allows function viewport point to ray
    [SerializeField] private Transform PickupTarget;
    [Space]
    [SerializeField] private float PickupRange;
    private Rigidbody CurrentObject;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //there is an error somewhere below, I think we need more if statements before we run the picking up code
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {


            if (CurrentObject)
                {
                    CurrentObject.useGravity = true;
                    CurrentObject = null;
                FindObjectOfType<SAudioManager>().Play("pop");
                return;

                }

                Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
                {
                FindObjectOfType<SAudioManager>().Play("pop");
                CurrentObject = HitInfo.rigidbody;
                    CurrentObject.useGravity = false;
                
                }
            }
    }

    void FixedUpdate() 
    {
        if(CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 6f * DistanceToPoint;
            

        }
    }
}