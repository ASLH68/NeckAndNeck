using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{


    private void OnEnable()
    {
        StartCoroutine(SetSelectedButton());
    }

    private IEnumerator SetSelectedButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.firstSelectedGameObject = transform.GetChild(0).gameObject;
        EventSystem.current.SetSelectedGameObject(transform.GetChild(0).gameObject); 
    }
}
