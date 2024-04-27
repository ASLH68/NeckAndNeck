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
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    #region Serialized Vars

    [SerializeField] float _endDelay;
    [SerializeField] private GameObject _menuObjects;
    [SerializeField] private TextMeshProUGUI _winText;

    [Header("SFX")]
    [SerializeField] private FMODUnity.StudioEventEmitter _boundsSFX;
    [SerializeField] private FMODUnity.StudioEventEmitter _victorSFX;

    #endregion

    #region Private Variables

    private int _winnerNum;

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
            WinTrigger.OnPlayerDied += BeginEndTransition;
        }
        else
        {
            WinTrigger.OnPlayerDied -= BeginEndTransition;
        }
    }

    #endregion

    #region UI Functionality

    private void BeginEndTransition(int playerNum)
    {
        _winnerNum = playerNum;
        PlaySFX(_boundsSFX);
        StartCoroutine(EnableEnding());
    }

    private IEnumerator EnableEnding()
    {
        yield return new WaitForSeconds(_endDelay);
        PlaySFX(_victorSFX);
        SetWinText(_winnerNum);  
    }

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
        switch(playerNum)
        {
            case 1:
                _winText.text = "Brown Team Victory!";
                break;
            case 2:
                _winText.text = "Yellow Team Victory!";
                break;
            default:
                break;
        }
        ShowEndScreen(true);
    }

    #endregion

    #region SFX

    /// <summary>
    /// Plays a sfxx
    /// </summary>
    /// <param name="sfx">sfx to be played</param>
    private void PlaySFX(FMODUnity.StudioEventEmitter sfx)
    {
        sfx.Play();
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
