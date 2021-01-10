using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float sideSpeed;
    public float jumpAmount;

    public Rigidbody pinggang;
    public bool isGround;
    public Animator animator;
    private copyMotion rightFoot;
    private copyMotion leftFoot;

    // Start is called before the first frame update
    void Start()
    {
        pinggang = GetComponent<Rigidbody>();
        rightFoot = GameObject.FindGameObjectWithTag("kakiKanan").GetComponent<copyMotion>();
        leftFoot = GameObject.FindGameObjectWithTag("kakiKiri").GetComponent<copyMotion>();
    }

    private void FixedUpdate()
    {
        
        //MOVEMENT Z Axis 
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);
                leftSprint(-speed, "forward");
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);
                pinggang.AddForce(pinggang.transform.forward * -speed);
            }
        }
        else
        {
            //SUMBU Z
            animator.SetBool("isRun", false);
            animator.SetBool("isWalk", false);
            animator.SetBool("isRight", false);

            //SUMBU X
            rightFoot.mirror = false;
            animator.SetBool("isRight", false);
            leftFoot.mirror = false;
            animator.SetBool("isLeft", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", true);
                leftSprint(speed, "forward");
            }
            else
            {
                animator.SetBool("isRun", false);
                animator.SetBool("isWalk", true);
                pinggang.AddForce(pinggang.transform.forward * speed);
            }
        }

        //MOVEMENT X Axis 
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                leftSprint(sideSpeed, "right");
            }
            else
            {
                leftFoot.mirror = true;
                animator.SetBool("isLeft", true);
                pinggang.AddForce(pinggang.transform.right * sideSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                leftSprint(-sideSpeed, "right");
            }
            else
            {
                rightFoot.mirror = true;
                animator.SetBool("isRight", true);
                pinggang.AddForce(pinggang.transform.right * -sideSpeed);
            }
        }

        if(Input.GetAxis("Jump") > 0)
        {
            if (isGround)
            {
                pinggang.AddForce(new Vector3(0, jumpAmount, 0));
                isGround = false;
            }
        }
    }


    //SPRINT FUNCTION
    private void leftSprint(float Sprint, string axis)
    {
        if (axis == "forward")
        {
            pinggang.AddForce(pinggang.transform.forward * Sprint * 2f);
        }
        else if (axis == "right")
        {
            pinggang.AddForce(pinggang.transform.right * Sprint * 2f);
        }
    }
}
