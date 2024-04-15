using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IController : MonoBehaviour
{
    protected PlayerInput playerInputComponent;
    protected int controllerIndex;
    protected JoinPlayers playerManager;

    public void SwapGamepad(int index)
    {
        playerInputComponent.SwitchCurrentControlScheme(Gamepad.all[index]);
    }
}
