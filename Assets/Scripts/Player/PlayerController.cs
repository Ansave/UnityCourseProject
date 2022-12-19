using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour, IMovable
{
    // Физика и перемещение
    [Header("Перемещение")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float dashMaxLength = 12f;
    [SerializeField] private float dashPad = 2f;
    private Rigidbody myRigidbody;
    private BoxCollider boxCollider;
    private Vector3 movementDirection;

    // Вид и прицеливание
    [Header("Вид и прицеливание")]
    [SerializeField] private Transform sight;
    private Matrix4x4 isometryRotationMatrix;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        SetCameraMatrix();
        
        void SetCameraMatrix()
        {
            var isometryAngle = Camera.main.transform.eulerAngles.y;
            isometryRotationMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, isometryAngle, 0));
        }
    }
    
    void Update()
    {
        Look();
        if (Input.GetKeyDown(KeyCode.LeftShift)) Dash();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void SetMovementDirection()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        movementDirection = isometryRotationMatrix.MultiplyVector(inputDirection);
    }

    public void Move()
    {
        SetMovementDirection();
        myRigidbody.AddForce(movementDirection * speed, ForceMode.Force);
    }

    private void Look()
    {
        Vector3 direction = sight.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    private void Dash()
    {
        if (Physics.BoxCast(transform.position, boxCollider.size / 2, movementDirection, 
            out RaycastHit hitInfo, transform.rotation, dashMaxLength)) {
            var dash = movementDirection * (hitInfo.distance - dashPad);
            transform.Translate(dash,Space.World);
        }
        else {
            transform.Translate(movementDirection * dashMaxLength, Space.World);
        }

    }

}
