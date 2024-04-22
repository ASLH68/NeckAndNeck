/*****************************************************************************
// File Name :         JoinPlayers.cs
// Author :            Nick Grinstead
// Creation Date :     04/15/24
//
// Brief Description : Handles spawning giraffe's and assigning input devices in
                        character select screen.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoinPlayers : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject confirmationDialogue;

    [SerializeField] GameObject firstButton;
    [SerializeField] GameObject noButton;
    [SerializeField] GameObject selectMenuUI;
    [SerializeField] GameObject[] text;
    float[] textPositions = { -338, -110, 116, 341 };
 
    Gamepad[] gamepads;
    List<IController> controllerArray = new List<IController>();

    int[] gamepadOrder = { -1, -1, -1, -1 }; 
    bool[] isCharacterAvailable = { true, true, true, true };
    int gamepadIndex = 0;

    Track camTracker;

    private void Start()
    {
        GameObject temp = Instantiate(playerPrefab);
        controllerArray.Add(temp.GetComponentInChildren<HeadController>());
        controllerArray.Add(temp.GetComponentInChildren<GiraffeController>());
        
        temp = Instantiate(playerPrefab);
        controllerArray.Add(temp.GetComponentInChildren<HeadController>());
        controllerArray.Add(temp.GetComponentInChildren<GiraffeController>());

        camTracker = GetComponent<Track>();
        camTracker.SetPlayers();
        camTracker.TrackPlayer();

        gamepads = Gamepad.all.ToArray();


        //controllerArray[0].ToggleControlScheme("Menu");
        controllerArray[0].ToggleInput(true);
        for (int i = 1; i < controllerArray.Count; ++i)
        {
            //controllerArray[i].ToggleControlScheme("SinglePlayer");
            controllerArray[i].ToggleInput(false);
        }

        for (int i = 0; i < text.Length; ++i)
        {
            text[i].SetActive(false);
        }
    }

    public void SelectCharacter(int characterIndex)
    {
        if (isCharacterAvailable[characterIndex])
        {
            EventSystem.current.SetSelectedGameObject(null);
            StartCoroutine(SelectButton(firstButton));

            isCharacterAvailable[characterIndex] = false;
            Vector3 temp = text[characterIndex].transform.localPosition;
            text[gamepadIndex].transform.localPosition = new Vector3(textPositions[characterIndex], temp.y, temp.z);
            text[gamepadIndex].SetActive(true);

            gamepadOrder[characterIndex] = gamepadIndex;
            //controllerArray[gamepadIndex].ToggleInput(false);
            gamepadIndex++;

            if (gamepadIndex >= Gamepad.all.Count)
            {
                confirmationDialogue.SetActive(true);

                EventSystem.current.SetSelectedGameObject(null);
                StartCoroutine(SelectButton(noButton));
            }
            else
            {
                //controllerArray[0].SwapGamepad(gamepadIndex);
                //controllerArray[gamepadIndex - 1].ToggleControlScheme("SinglePlayer");
                
                //controllerArray[gamepadIndex].ToggleControlScheme("Menu");
                //controllerArray[gamepadIndex].ToggleInput(true);
                controllerArray[0].SwapGamepad(gamepadIndex);
                controllerArray[gamepadIndex].SwapGamepad(gamepadIndex - 1);
            }
        }
    }

    public void BeginPlay()
    {
        for (int i = 0; i < gamepads.Length; ++i)
        {
            if (gamepadOrder[i] != -1)
            {
                controllerArray[i].SwapGamepad(gamepadOrder[i]);
            }
            //controllerArray[i].ToggleControlScheme("SinglePlayer");
            //controllerArray[i].ToggleInput(true);
            controllerArray[i].ActivateCharacter();
        }

        selectMenuUI.SetActive(false);
    }

    public void ClearSelectedCharacters()
    {
        EventSystem.current.SetSelectedGameObject(null);
        StartCoroutine(SelectButton(firstButton));

        gamepadIndex = 0;
        //controllerArray[0].SwapGamepad(gamepadIndex);

        //controllerArray[0].ToggleControlScheme("Menu");
        controllerArray[0].ToggleInput(true);
        for (int i = 1; i < controllerArray.Count; ++i)
        {
            //controllerArray[i].ToggleControlScheme("SinglePlayer");
            controllerArray[i].ToggleInput(false);
        }

        for (int i = 0; i < isCharacterAvailable.Length && i < gamepadOrder.Length && i < text.Length; ++i)
        {
            text[i].SetActive(false);
            isCharacterAvailable[i] = true;
            gamepadOrder[i] = -1;
        }
    }

    private IEnumerator SelectButton(GameObject button)
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(button);
    }
}
