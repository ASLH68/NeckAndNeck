using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    //These will need to be set to the respective boxes
    [SerializeField] private GameObject _playerOneTracker;
    [SerializeField] private GameObject _playerTwoTracker;

    private GameObject _player1;
    private GameObject _player2;

    //Once the actual players are set call this function
    public void TrackPlayer()
    {
        _playerOneTracker.transform.parent = _player1.transform;
        _playerTwoTracker.transform.parent = _player2.transform;
    }

    //Call this function when the actual players spawn in
    public void SetPlayers()
    {
        _player1 = GameObject.FindGameObjectWithTag("Player1");
        _player2 = GameObject.FindGameObjectWithTag("Player2");
    }
}
