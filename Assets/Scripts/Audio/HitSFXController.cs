using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitSFXController : MonoBehaviour
{
    #region Serialized Variables

    [SerializeField] private float _hitSFXCooldown;

    #endregion

    #region Private Variables

    private FMODUnity.StudioEventEmitter _hitSFX;
    private IEnumerator _cooldownCoroutine;
    private bool _canPlaySFX = false;

    #endregion

    private void Start()
    {
        _hitSFX = GetComponent<FMODUnity.StudioEventEmitter>();
        _cooldownCoroutine = HitSFXCooldown();
    }

    private void OnEnable()
    {
        GiraffeCollision.OnHit += PlayHitSFX;
    }
    private void OnDisable()
    {
        GiraffeCollision.OnHit -= PlayHitSFX;
    }

    private void PlayHitSFX()
    {
        if(_canPlaySFX)
        {
            StartCoroutine(_cooldownCoroutine);
        }
    }

    /// <summary>
    /// Plays an SFX then has a cooldown period before can play again
    /// </summary>
    /// <returns></returns>
    private IEnumerator HitSFXCooldown()
    {
        _canPlaySFX = false;
        _hitSFX.Play();
        yield return new WaitForSeconds(_hitSFXCooldown);
        _canPlaySFX = true;
    }
}
