using UnityEngine;

public class Alarm : MonoBehaviour
{
    private const int MaxVolume = 1;
    private const int MinVolume = 0;

    [SerializeField] private float _volumeChangeSpeed = 0.5f;

    private AudioSource _audioSource;
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
            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, MaxVolume, _volumeChangeSpeed * Time.deltaTime);
        }
        else
        {
            _audioSource.volume =
                Mathf.MoveTowards(_audioSource.volume, MinVolume, _volumeChangeSpeed * Time.deltaTime);

            if (_audioSource.volume == MinVolume)
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