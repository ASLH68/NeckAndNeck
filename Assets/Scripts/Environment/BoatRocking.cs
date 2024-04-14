using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoatRocking : MonoBehaviour
{
    float originalY;
    private Quaternion startRotation;
    [SerializeField] public float bobbingMultiplier = .5f;
    [SerializeField] public float rollMultiplier = .4f;

    void Start()
    {
        originalY = this.transform.position.y;
        startRotation = transform.rotation;
    }

    void Update()
    {
        BobUpAndDown();
        Roll();

        /*RollSideToSide();
        RollFrontToBack();*/
    }

    void BobUpAndDown()
    {
        transform.position = new Vector3(transform.position.x, originalY + ((float)Math.Sin(Time.time) * bobbingMultiplier), transform.position.z);
    }

    void Roll()
    {
        float f = Mathf.Sin(Time.time * rollMultiplier) * 2f; //Side to side motion
        float f2 = Mathf.Sin(Time.time * rollMultiplier) * 2f; //Front to back motion
        transform.rotation = startRotation * Quaternion.AngleAxis(f, Vector3.forward) * Quaternion.AngleAxis(f2, Vector3.left);
    }

/*    void RollSideToSide()
    {
        float f = Mathf.Sin(Time.time * rollMultiplier) * 10f;
        transform.rotation = startRotation * Quaternion.AngleAxis(f, Vector3.forward);
    }

    void RollFrontToBack()
    {
        float f = Mathf.Sin(Time.time * rollMultiplier) * 2f;
        transform.rotation = startRotation * Quaternion.AngleAxis(f, Vector3.left);
    }*/
}
