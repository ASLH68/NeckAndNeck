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
        if (other.CompareTag("Player1") && other.TryGetComponent<GiraffeController>(out GiraffeController gc))
        {
            OnPlayerDied?.Invoke(1);
        }
        else if (other.CompareTag("Player2") && other.TryGetComponent<GiraffeController>(out GiraffeController gc2))
        {
            OnPlayerDied?.Invoke(2);
        }
    }

    #endregion
}
