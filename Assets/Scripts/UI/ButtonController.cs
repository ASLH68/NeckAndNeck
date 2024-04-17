using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    private void OnEnable()
    {
        EventSystem.current.firstSelectedGameObject = transform.GetChild(0).gameObject;
    }
}
