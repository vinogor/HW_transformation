using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _targetX;
    [SerializeField] private float _pathTime;

    private Transform _transform;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _currentPathRunningTime;
    private int _directionCoefficient = 1;

    void Start()
    {
        _transform = gameObject.transform;
        _startPosition = _transform.position;
        _targetPosition = new Vector3(_targetX, _startPosition.y, _startPosition.z);
    }

    void Update()
    {
        _currentPathRunningTime += _directionCoefficient * Time.deltaTime;
        _transform.position = Vector3.Lerp(_startPosition, _targetPosition, _currentPathRunningTime / _pathTime);

        if (_transform.position == _targetPosition)
        {
            _directionCoefficient = -1;
        }

        if (_transform.position == _startPosition)
        {
            _directionCoefficient = 1;
        }
    }
}