/*****************************************************************************
// File Name :         HeadController.cs
// Author :            Nick Grinstead
// Creation Date :     04/15/24
//
// Brief Description : Interface for player controller scripts. Allows for 
                        changing control schemes and gamepads.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IController : MonoBehaviour
{
    private PlayerInput playerInputComponent;
    protected bool canMove = false;

    public PlayerInput PlayerInputComponent { get => playerInputComponent; set => playerInputComponent = value; }

    public void SwapGamepad(int index)
    {
        PlayerInputComponent.SwitchCurrentControlScheme(Gamepad.all[index]);
    }

    public void ActivateCharacter()
    {
        canMove = true;
    }

    public void ToggleControlScheme(string actionMap)
    {
        playerInputComponent.SwitchCurrentActionMap(actionMap);
    }
}
