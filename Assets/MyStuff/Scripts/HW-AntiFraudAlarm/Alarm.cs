using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private float _volumeChangeSpeed = 0.5f;
    private bool _isSoundOn;

    private void Start()
    {
        _audioSource = GetComponentInChildren<AudioSource>();
        _audioSource.volume = 0;
    }

    private void Update()
    {
        if (_isSoundOn)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, _volumeChangeSpeed * Time.deltaTime);
        }
        else
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _volumeChangeSpeed * Time.deltaTime);

            if (_audioSource.volume == 0)
            {
                _audioSource.Stop();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isSoundOn = true;
        _audioSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        _isSoundOn = false;
    }
}