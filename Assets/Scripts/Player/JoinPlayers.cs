using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinPlayers : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] PlayerInputManager inputManager;

    List<IController> controllerArray = new List<IController>();

    // TODO provide each IController with its index (0 = P1 head, 1 = P1 body, 2 = P2 head, 3 = P2 body)
        // each IController needs a method that calls back to this script in order to swap gamepads
        // with another IController

    private void Start()
    {
        GameObject temp = Instantiate(playerPrefab);
        controllerArray.Add(temp.GetComponentInChildren<HeadController>());
        controllerArray.Add(temp.GetComponentInChildren<GiraffeController>());
        
        temp = Instantiate(playerPrefab);
        controllerArray.Add(temp.GetComponentInChildren<HeadController>());
        controllerArray.Add(temp.GetComponentInChildren<GiraffeController>());

        //for (int i = 3; i >= 0; --i)
        //{
        //    controllerArray[i].SwapGamepad(0 + (3 - i));
        //}
    }
}
