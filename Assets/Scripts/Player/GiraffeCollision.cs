using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeCollision : MonoBehaviour
{
    Rigidbody rb;
    Transform player1;
    Transform player2;
    Vector3 hitVector;

    [SerializeField] FMODUnity.StudioEventEmitter _hitSFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    private void Start()
    {
        _hitSFX = transform.parent.GetComponent<FMODUnity.StudioEventEmitter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            _hitSFX.Play();
            if (player1 == null || player2 == null)
            {
                player1 = GiraffeController.secondPlayerInstance.transform;
                player2 = GiraffeController.firstPlayerInstance.transform;
                
            }

            float selfVelocity = Mathf.Abs(rb.velocity.magnitude);
            float otherVelocity = Mathf.Abs(collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude);

            if (Mathf.Abs(selfVelocity - otherVelocity) > 1f)
            {
                if (collision.gameObject.CompareTag("Player1"))
                {   
                    hitVector = player1.position - player2.position;
                    hitVector.Normalize();

                    if (selfVelocity < otherVelocity)
                    {
                        GiraffeController.secondPlayerInstance.GotHit(true, hitVector);
                        GiraffeController.firstPlayerInstance.GotHit(false);
                    }
                }
                else if (collision.gameObject.CompareTag("Player2"))
                {   
                    hitVector = player2.position - player1.position;
                    hitVector.Normalize();

                    if (selfVelocity < otherVelocity)
                    {
                        GiraffeController.firstPlayerInstance.GotHit(true, hitVector);
                        GiraffeController.secondPlayerInstance.GotHit(false);
                    }
                }
            }
        }
    }
}
