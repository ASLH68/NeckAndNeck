/*****************************************************************************
// File Name :         HeadController.cs
// Author :            Nick Grinstead
// Creation Date :     04/11/24
//
// Brief Description : Takes player inputs for controlling the giraffe's head.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadController : IController
{
    [SerializeField] float moveSpeed;
    float xAxis, zAxis;
    Vector3 moveDirection;
    Transform cameraTrans;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerInputComponent = GetComponent<PlayerInput>();
        cameraTrans = Camera.main.transform;

        GetComponent<TrailRenderer>().time = 0.05f;
    }

    private void Update()
    {
        moveDirection = new Vector3(xAxis, 0f, zAxis).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
            Vector3 correctedDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.velocity = correctedDirection.normalized * moveSpeed * Time.deltaTime;
        }
    }

    public void OnMoveNeckX(InputValue context)
    {
        if (canMove)
            xAxis = context.Get<float>();
    }

    public void OnMoveNeckZ(InputValue context)
    {
        if (canMove)
            zAxis = context.Get<float>();
    }
}
