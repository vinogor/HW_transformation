using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    private static float s_fullRotationAngle = 360;

    [SerializeField] private float _oneRotationTime;

    private float _currentPathRunningTime;

    private void Update()
    {
        _currentPathRunningTime += Time.deltaTime;
        transform.rotation =
            Quaternion.AngleAxis(s_fullRotationAngle * _currentPathRunningTime / _oneRotationTime, Vector3.up);
    }
}