/*****************************************************************************
// File Name :         GiraffeController.cs
// Author :            Nick Grinstead
// Creation Date :     04/10/24
//
// Brief Description : Takes player inputs for controlling the giraffe's body.
*****************************************************************************/
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GiraffeController : IController
{
    [SerializeField] float moveSpeed;
    float xAxis, zAxis;
    Vector3 moveDirection;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Transform cameraTrans;
    
    Rigidbody rb;

    Vector3 firstPosition = new Vector3(2.4f, 18.52f, -6f);
    Vector3 secondPosition = new Vector3(2.4f, 18.52f, -40f);

    bool canGetHit = true;
    [SerializeField] float knockBackStrength;

    public static GiraffeController firstPlayerInstance;
    public static GiraffeController secondPlayerInstance;

    Animator bodyAnimator;

    private void Awake()
    {
        bodyAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        PlayerInputComponent = GetComponent<PlayerInput>();
        cameraTrans = Camera.main.transform;

        if (firstPlayerInstance == null)
        {
            firstPlayerInstance = this;
            transform.parent.position = firstPosition;
        }
        else if (secondPlayerInstance == null)
        {
            secondPlayerInstance = this;
            transform.parent.position = secondPosition;
        }
    }

    private void Update()
    {
        moveDirection = new Vector3(xAxis, 0f, zAxis).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle - 90f, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 correctedDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.velocity = correctedDirection.normalized * moveSpeed * Time.deltaTime;

            if (!GetComponent<FMODUnity.StudioEventEmitter>().IsPlaying())
            {
                GetComponent<FMODUnity.StudioEventEmitter>().Play();
            }
            
        }
        else
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        }
    }

    public void GotHit(bool hit, Vector3 hitDirection = new Vector3())
    {
        if (canGetHit)
        {
            canGetHit = false;
            //StartCoroutine(InvincibilityTimer());
            // TODO: Play animations here
            bodyAnimator.StartPlayback();

            if (hit)
            {
                rb.AddForce(hitDirection * knockBackStrength);
            }
        }
    }

    public void EndInvincibility()
    {
        Debug.Log("IFramesOver");
        canGetHit = true;
    }

    private IEnumerator InvincibilityTimer()
    {
        yield return new WaitForSeconds(0.5f);

        canGetHit = true;
    }

    public void OnMoveX(InputValue context)
    {
        if (canMove)
            xAxis = context.Get<float>();
    }

    public void OnMoveZ(InputValue context)
    {
        if (canMove)
            zAxis = context.Get<float>();
    }
}
