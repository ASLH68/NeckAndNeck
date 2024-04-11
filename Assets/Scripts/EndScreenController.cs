/*****************************************************************************
// File Name :         EndScreenController.cs
// Author :            Andrea Swihart-DeCoster
// Creation Date :     04/10/24
//
// Brief Description : Controls the end-game screen.
*****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    #region Private Variables

    [SerializeField] private GameObject _menuObjects;
    [SerializeField] private TextMeshProUGUI _winText;

    #endregion

    #region Unity Functions

    private void Start()
    {
        ShowEndScreen(false);
    }

    private void OnEnable()
    {
        ActionSubscription(true);
    }

    private void OnDisable()
    {
        ActionSubscription(false);
    }

    #endregion

    #region Action Handling

    /// <summary>
    /// Subscribes to and from actions
    /// </summary>
    /// <param name="isEnabling">If enabling or disabling obj</param>
    private void ActionSubscription(bool isEnabling)
    {
        if (isEnabling)
        {
            WinTrigger.OnPlayerDied += SetWinText;
        }
        else
        {
            WinTrigger.OnPlayerDied -= SetWinText;
        }
    }

    #endregion

    #region UI Functionality

    /// <summary>
    /// Enables and disables end screen visibility
    /// </summary>
    /// <param name="isVisible">Should screen be visible?</param>
    private void ShowEndScreen(bool isVisible)
    {
        _menuObjects.SetActive(isVisible);
    }

    /// <summary>
    /// Sets the win text to display the winning player
    /// </summary>
    /// <param name="playerNum">Num player who won</param>
    private void SetWinText(int playerNum)
    {
        _winText.text = "Player " + playerNum + " Wins!";
        ShowEndScreen(true);
    }

    #endregion

    #region End Screen Buttons

    /// <summary>
    /// Restarts game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    /// <summary>
    /// Returns to main menu
    /// </summary>
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        print("quit");
        Application.Quit();
    }

    #endregion
}
