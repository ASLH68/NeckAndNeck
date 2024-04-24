using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField] GameObject hitEffect;
    void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            Hit();
        }
    }
    void Hit()
    {
        GameObject hitObject = Instantiate(hitEffect, position, Quaternion.identity);
        hitObject.GetComponent<ParticleSystem>().Play();
    }
}
