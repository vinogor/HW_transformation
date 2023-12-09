using UnityEngine;

public class Cube : MonoBehaviour
{
    private static float s_fullRotationAngle = 360;

    [SerializeField] private float _oneRotationTime;

    private Transform _transform;
    private float _currentPathRunningTime;

    void Start()
    {
        _transform = gameObject.transform;
    }

    void Update()
    {
        _currentPathRunningTime += Time.deltaTime;
        _transform.rotation =
            Quaternion.AngleAxis(s_fullRotationAngle * _currentPathRunningTime / _oneRotationTime, Vector3.up);
    }
}