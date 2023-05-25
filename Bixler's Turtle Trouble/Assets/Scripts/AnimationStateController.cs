using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("Animator: " + animator);
    }

    // Update is called once per frame
    void Update()
    {
        
    //Walking code
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("isWalking", false);
        }

    //Walking backwards code
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isWalkingBackwards", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isWalkingBackwards", false);
        }

    //Strafing left code
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("isStrafingLeft", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isStrafingLeft", false);
        }

    //Strafing right code
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("isStrafingRight", true);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isStrafingRight", false);
        }    

    //Running code
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", false);
        }

    //Jumping code
       if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
        }
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");
        // animator.SetFloat("Speed", vertical);
        // animator.SetFloat("Direction", horizontal);
       
    }
}
