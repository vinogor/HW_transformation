using UnityEngine;

public class Object3DMover : MonoBehaviour
{
    [SerializeField] private Vector3 _targetVector;
    [SerializeField] private float _pathTime;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _currentPathRunningTime;
    private int _directionCoefficient = 1;

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = _targetVector;
    }

    private void Update()
    {
        _currentPathRunningTime += _directionCoefficient * Time.deltaTime;
        transform.position = Vector3.Lerp(_startPosition, _targetPosition, _currentPathRunningTime / _pathTime);

        if (transform.position == _targetPosition)
        {
            _directionCoefficient = -1;
        }

        if (transform.position == _startPosition)
        {
            _directionCoefficient = 1;
        }
    }
}