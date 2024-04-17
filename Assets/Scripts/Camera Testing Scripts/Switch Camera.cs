using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject _camera1;
    [SerializeField] private GameObject _camera2;

    //[SerializeField] private bool _switch;

    private GameObject _player1;
    private GameObject _player2;

    //Call this function to activate the screen transition
    public void ChangeCamera()
    {
        GetComponent<Animator>().SetTrigger("Change");
    }

    //Don't worry about this function
    public void ManageCamera()
    {
        Cam2();

        Destroy(_player1);
        Destroy(_player2);
    }

    //Call this function when the fake players spawn in
    public void SetPlayers()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");
    }

    /*private void Cam1()
    {
        _camera1.SetActive(true);
        _camera2.SetActive(false);
    }*/

    //Don't worry about this
    private void Cam2()
    {
        _camera1.SetActive(false);
        _camera2.SetActive(true);
    }
}
