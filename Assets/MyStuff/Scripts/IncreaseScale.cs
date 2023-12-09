using UnityEngine;

public class Capsule : MonoBehaviour

{
    [SerializeField] private float _scaleIncreaseTime;
    [SerializeField] private float _scaleIncreaseCoefficient;

    private Transform _transform;
    private float _currentPathRunningTime;
    private Vector3 _startScale;
    private Vector3 _targetScale;
    private int _directionCoefficient = 1;

    void Start()
    {
        _transform = gameObject.transform;
        _startScale = _transform.localScale;
        _targetScale = new Vector3(
            _startScale.x * _scaleIncreaseCoefficient,
            _startScale.y * _scaleIncreaseCoefficient,
            _startScale.z * _scaleIncreaseCoefficient);
    }

    void Update()
    {
        _currentPathRunningTime += _directionCoefficient * Time.deltaTime;

        _transform.localScale = Vector3.Lerp(_startScale, _targetScale, _currentPathRunningTime / _scaleIncreaseTime);

        if (_transform.localScale == _targetScale)
        {
            _directionCoefficient = -1;
        }

        if (_transform.localScale == _startScale)
        {
            _directionCoefficient = 1;
        }
    }
}