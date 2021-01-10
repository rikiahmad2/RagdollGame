using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbed : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    GameObject grabbedObject;
    public Rigidbody rb;
    public int isLeftorRight;
    public bool isGrabbing = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(isLeftorRight))
        {
            if(isLeftorRight == 0)
            {
                anim.SetBool("isLeftUp", true);
            }
            else if (isLeftorRight == 1)
            {
                anim.SetBool("isRightHandUp", true);
            }
            FixedJoint fj = grabbedObject.AddComponent<FixedJoint>();
            fj.connectedBody = rb;
            fj.breakForce = 9001;
        } 
        else if(Input.GetMouseButtonUp(isLeftorRight)) {
            if (isLeftorRight == 0)
            {
                anim.SetBool("isLeftUp", false);
            }
            else if (isLeftorRight == 1)
            {
                anim.SetBool("isRightHandUp", false);
            }

            if(grabbedObject != null)
            {
                Destroy(grabbedObject.GetComponent<FixedJoint>());
            }

            grabbedObject = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            grabbedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grabbedObject = null;
    }
}
