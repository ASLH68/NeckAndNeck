using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class LightningSpawner : MonoBehaviour
{
    [SerializeField] VisualEffect lightning;

    private void Start()
    {
        StartCoroutine(RandomWait());
    } 

    //random wait time for each bolt of lightning
    IEnumerator RandomWait()
    {
        while (true) 
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(40, 100),-10,Random.Range(-65, 35)); //Randomizes the spawn position in world
            Quaternion randomVeticalRotation = Quaternion.Euler(0,Random.Range(0f,360f),0); //Randomizes the spawn y-axis rotation
            Instantiate(lightning, randomSpawnPosition, randomVeticalRotation); //Instantiates a lightning bolt
            lightning.Play();
            yield return new WaitForSeconds(Random.Range(3,8)); //Random range before corutine repeats
        }
    }
}
