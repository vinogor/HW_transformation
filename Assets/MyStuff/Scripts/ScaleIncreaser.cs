using UnityEngine;

public class ScaleIncreaser : MonoBehaviour

{
    [SerializeField] private float _scaleIncreaseTime;
    [SerializeField] private float _scaleIncreaseCoefficient;

    private float _currentPathRunningTime;
    private Vector3 _startScale;
    private Vector3 _targetScale;
    private int _directionCoefficient = 1;

    private void Start()
    {
        _startScale = gameObject.transform.localScale;
        _targetScale = new Vector3(
            _startScale.x * _scaleIncreaseCoefficient,
            _startScale.y * _scaleIncreaseCoefficient,
            _startScale.z * _scaleIncreaseCoefficient);
    }

    private void Update()
    {
        _currentPathRunningTime += _directionCoefficient * Time.deltaTime;
        transform.localScale = Vector3.Lerp(_startScale, _targetScale, _currentPathRunningTime / _scaleIncreaseTime);

        if (transform.localScale == _targetScale)
        {
            _directionCoefficient = -1;
        }

        if (transform.localScale == _startScale)
        {
            _directionCoefficient = 1;
        }
    }
}