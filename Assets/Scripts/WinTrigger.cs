/*****************************************************************************
// File Name :         WinTrigger.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     04/10/24
//
// Brief Description : Controls the end-game state and transitions
*****************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    #region Actions

    public static Action<int> OnPlayerDied;

    #endregion

    #region Collisions

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.CompareTag("Player1"))
        {
            OnPlayerDied?.Invoke(1);
        }
        else if (other.transform.parent.CompareTag("Player2"))
        {
            OnPlayerDied?.Invoke(2);
        }
    }

    #endregion
}
