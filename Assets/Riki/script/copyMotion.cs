using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copyMotion : MonoBehaviour
{
    public Transform targetLimb;
    ConfigurableJoint cj;
    public bool mirror;

    void Start()
    {
        cj = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!mirror)
        {
            cj.targetRotation = targetLimb.rotation;
        }
        else
        {
            cj.targetRotation = Quaternion.Inverse(targetLimb.rotation);
        }
       
    }
}
