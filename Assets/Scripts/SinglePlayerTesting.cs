using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SinglePlayerTesting : MonoBehaviour
{
    [SerializeField] GameObject testDummy;
    [SerializeField] TextMeshProUGUI instructions;
    Track camTracker;

    private void Update()
    {
        if (GiraffeController.firstPlayerInstance != null)
        {
            EnableTestDummy();
        }
    }

    private void EnableTestDummy()
    {
        instructions.enabled = false;
        testDummy.SetActive(true);

        camTracker = GetComponent<Track>();
        camTracker.SetPlayers();
        camTracker.TrackPlayer();

    }
}
