using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    float xAxis, zAxis;
    Vector3 moveDirection;
    Transform cameraTrans;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cameraTrans = Camera.main.transform;
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
        xAxis = context.Get<float>();
    }

    public void OnMoveNeckZ(InputValue context)
    {
        zAxis = context.Get<float>();
    }
}
