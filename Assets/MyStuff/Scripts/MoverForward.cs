using UnityEngine;

public class MoverForward : MonoBehaviour
{
    [SerializeField] private float _targetX;
    [SerializeField] private float _pathTime;

    private Vector3 _startPosition;
    private Vector3 _targetPosition;
    private float _currentPathRunningTime;
    private int _directionCoefficient = 1;

    private void Start()
    {
        _startPosition = transform.position;
        _targetPosition = new Vector3(_targetX, _startPosition.y, _startPosition.z);
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