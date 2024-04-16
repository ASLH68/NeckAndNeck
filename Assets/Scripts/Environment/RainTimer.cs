/*
 * Controls heavy Rain
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainTimer : MonoBehaviour
{
    /// VARS
    // Timer Controls
    int _secondCount = -1;
    [SerializeField] int _breakDuration = 15;
    int _rainDuration = 15;
    int _rainEnd = 30;
    bool _isRaining = false;
    public bool isRaining { get => _isRaining; }

    // Probability Controls
    [SerializeField] int _rainChance = 25;
    int _increasedChance = 0;
    float _rainDice;

    // Referenced objs
    [SerializeField] PhysicMaterial _boatMaterial;
    [SerializeField] float _rainyFriction;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RainControlTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Timer that controls the spawning and duration of rain
    /// </summary>
    /// <returns></returns>
    IEnumerator RainControlTimer()
    {
        while(true)
        {
            // Increments timer
            _secondCount++;
            yield return new WaitForSeconds(1);

            // Controls whether to start the rain
            if (_secondCount == _breakDuration)
            {
                _rainDice = Random.Range(1, 100);
                if (_rainDice <= _rainChance)
                {
                    StartRain();
                    Debug.Log("raining");
                }
                else
                {
                    _secondCount = -1;
                    Debug.Log("failed");
                }

                // Tells rain when to end
                _rainEnd = _secondCount + _rainDuration;

                // Increases chance of rain
                switch(_increasedChance)
                {
                    case 0:
                        _rainChance = 33;
                        _increasedChance++;
                        break;
                    case 1:
                        _rainChance = 50;
                        break;
                }

                // Decreases cycle time
                if (_breakDuration > 1)
                    _breakDuration--;
            }

            // Controls the end of rain and resets timer
            if (_secondCount == _rainEnd)
            {
                StopRain();
                Debug.Log("stopped raining");
                _secondCount = -1;
            }

        }
    }

    /// <summary>
    /// Controls effects of the rain
    /// </summary>
    public void StartRain()
    {
        // Changes boat friction
        _boatMaterial.dynamicFriction = _rainyFriction;
        _boatMaterial.staticFriction = _rainyFriction;
    }

    /// <summary>
    /// Controls ending of rain, basically undoes everything in StartRain
    /// </summary>
    void StopRain()
    {
        // Resets friction
        _boatMaterial.dynamicFriction = .6f;
        _boatMaterial.staticFriction = .6f;

        // Increases duration of future rains
        _rainDuration += 5;
    }
}
