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
    [SerializeField] private float speedScale = 1f;
    [SerializeField] private float dashLength = 12f;
    private Rigidbody myRigidbody;
    private Vector3 movementDirection;

    // Вид и прицеливание
    [Header("Вид и прицеливание")]
    [SerializeField] private Transform sight;
    private Matrix4x4 isometryRotationMatrix;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
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
        myRigidbody.AddForce(movementDirection * speedScale, ForceMode.Force);
    }

    private void Look()
    {
        Vector3 direction = sight.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    private void Dash()
    {
        transform.Translate(myRigidbody.velocity.normalized * dashLength,Space.World);
    }

}
