using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLightning : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject,1.2f);
    }
}
