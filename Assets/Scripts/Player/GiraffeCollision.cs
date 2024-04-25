using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class GiraffeCollision : MonoBehaviour
{
    Rigidbody rb;
    Transform player1;
    Transform player2;
    Vector3 hitVector;

    [SerializeField] FMODUnity.StudioEventEmitter _hitSFX;
    [SerializeField] GameObject hitVFX;

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
            StartCoroutine(Hit(collision.GetContact(0).point));

            _hitSFX.Play();
            if (player1 == null || player2 == null)
            {
                player1 = GiraffeController.secondPlayerInstance.transform;
                player2 = GiraffeController.firstPlayerInstance.transform;
                
            }

            float selfVelocity = Mathf.Abs(rb.velocity.magnitude);
            float otherVelocity = Mathf.Abs(collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude);

            float knockBackModifier = Mathf.Abs(selfVelocity - otherVelocity) / 3f;
            if (knockBackModifier < 0.33f)
                knockBackModifier = 0.33f;
            else if (knockBackModifier > 1.0f)
                knockBackModifier = 1.0f;

            if (collision.gameObject.CompareTag("Player1"))
            {
                hitVector = player1.position - player2.position;
                hitVector.Normalize();

                if (selfVelocity < otherVelocity)
                {
                    GiraffeController.secondPlayerInstance.GotHit(true, knockBackModifier, hitVector);
                    GiraffeController.firstPlayerInstance.GotHit(false);
                }
            }
            else if (collision.gameObject.CompareTag("Player2"))
            {   
                hitVector = player2.position - player1.position;
                hitVector.Normalize();

                if (selfVelocity < otherVelocity)
                {
                    GiraffeController.firstPlayerInstance.GotHit(true, knockBackModifier, hitVector);
                    GiraffeController.secondPlayerInstance.GotHit(false);
                }
            }
            
        }
    }

    IEnumerator Hit(Vector3 position)
    {
        if (VFXController.canHitVFX)
        {
            VFXController.canHitVFX = false;
            GameObject hitObject = Instantiate(hitVFX, position, Quaternion.identity);
            hitObject.GetComponent<ParticleSystem>().Play();
            yield return new WaitForSeconds(1);
            VFXController.canHitVFX = true;
        }
    }
}
