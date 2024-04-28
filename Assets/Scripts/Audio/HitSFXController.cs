using FMOD;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitSFXController : MonoBehaviour
{
    #region Serialized Variables

    [SerializeField] private float _hitSFXCooldown;
    [SerializeField] private FMODUnity.EventReference _hitSFXEventRef;
    [SerializeField] private float _pitchMin;
    [SerializeField] private float _pitchMax;

    #endregion

    #region Private Variables

    private FMODUnity.StudioEventEmitter _hitSFX;
    private FMOD.Studio.EventInstance _hitSFXEventInstance;

    #endregion

    private void Start()
    {
        _hitSFXEventInstance = FMODUnity.RuntimeManager.CreateInstance(_hitSFXEventRef);
        _hitSFXEventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));

        _hitSFX = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    private void OnEnable()
    {
        GiraffeController.OnHit += PlayHitSFX;
    }
    private void OnDisable()
    {
        GiraffeController.OnHit -= PlayHitSFX;
    }

    private void PlayHitSFX()
    {
        //_hitSFX.Play();
        _hitSFXEventInstance.start();
        PitchShift();    
    }

    /// <summary>
    /// Sets the pitch of the hit SFX
    /// </summary>
    private void PitchShift()
    {
        float newPitch = Random.Range(_pitchMin, _pitchMax);
        UnityEngine.Debug.Log(newPitch);
        _hitSFXEventInstance.setPitch(newPitch);
        _hitSFX.EventReference = _hitSFXEventRef;
    }
}
