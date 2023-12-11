using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    private const int MaxVolume = 1;
    private const int MinVolume = 0;

    [SerializeField] private float _volumeChangeDuration = 2f;

    private AudioSource _audioSource;
    private bool _isSoundOn;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void TurnOnSound()
    {
        StartCoroutine(ChangeVolume(_volumeChangeDuration, MaxVolume));
    }

    public void TurnOffSound()
    {
        StartCoroutine(ChangeVolume(_volumeChangeDuration, MinVolume));
    }

    private IEnumerator ChangeVolume(float duration, int targetVolume)
    {
        if (_isSoundOn == false && targetVolume == MaxVolume)
        {
            _isSoundOn = true;
            _audioSource.Play();
        }

        float timeCounter = 0;

        while (timeCounter < duration)
        {
            timeCounter += Time.deltaTime;
            float currentVolume = _audioSource.volume;
            float remainingVolumeDifference = Math.Abs(targetVolume - currentVolume);
            float remainingTimeDifference = duration - timeCounter;

            _audioSource.volume = Mathf.MoveTowards(currentVolume, targetVolume,
                remainingVolumeDifference / remainingTimeDifference * Time.deltaTime);

            yield return null;
        }

        if (_isSoundOn && targetVolume == MinVolume)
        {
            _isSoundOn = false;
            _audioSource.Stop();
        }
    }
}