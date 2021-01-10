using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    
    public Transform target;
    float mouseX, mouseY;
    public float stomachOffset;
    public ConfigurableJoint pinggangJoint, stomachJoint;
    public float smoothSpeed = 0.125f;
    
    [Header("Camera Settings")]
    public Vector3 offset;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    public float zoomSpeed = 2f;
    public float pitch = 2f;
    public float rotationSpeed = 0.05f;

    float currentZoom = 5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        bodyRotation();

        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
        offset = camTurnAngle * offset;
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }

    void bodyRotation()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -50, 20);

        Quaternion rootRotation = Quaternion.Euler(mouseY, mouseX, 0);
        target.rotation = rootRotation;

        pinggangJoint.targetRotation = Quaternion.Euler(0, -mouseX, 0);
        stomachJoint.targetRotation = Quaternion.Euler(-mouseY + stomachOffset, 0, 0);
    }
}
