using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UpdatePlayerLayer : MonoBehaviour
{
    private void Awake()
    {
       /* int numPlayers = PlayerInputManager.instance.playerCount;
        if (numPlayers == 2)
        {
            tag = "Player1";
            gameObject.layer = 6;

            foreach (Transform child in transform)
            {
                child.tag = "Player1";
                child.gameObject.layer = 6;

                foreach (Transform secondChild in child.transform)
                {
                    secondChild.tag = "Player1";
                    secondChild.gameObject.layer = 6;
                }
            }
        }
        else
        {
            tag = "Player2";
            gameObject.layer = 7;

            foreach (Transform child in transform)
            {
                child.tag = "Player2";
                child.gameObject.layer = 7;

                foreach (Transform secondChild in child.transform)
                {
                    secondChild.tag = "Player2";
                    secondChild.gameObject.layer = 7;
                }
            }
        }*/
    }
}
