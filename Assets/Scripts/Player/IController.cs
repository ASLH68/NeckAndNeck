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
    private InputActionMap menuMap;
    protected bool canMove = true;

    public PlayerInput PlayerInputComponent { get => playerInputComponent; set => playerInputComponent = value; }

    public void SwapGamepad(int index)
    {
        PlayerInputComponent.SwitchCurrentControlScheme(Gamepad.all[index]);
    }

    public void ActivateCharacter()
    {
        canMove = true;
    }

    public void DeactivateCharacter()
    {
        canMove = false;
    }

    public void ToggleControlScheme(string actionMap)
    {
        playerInputComponent.SwitchCurrentActionMap(actionMap);
    }

    public void ToggleInput(bool canGiveInput)
    {
        if (menuMap == null)
        {
            menuMap = playerInputComponent.actions.FindActionMap("Menu");
        }

        if (canGiveInput)
        {
            menuMap.Enable();
        }
        else
        {
            menuMap.Disable();
        }
    }
}
