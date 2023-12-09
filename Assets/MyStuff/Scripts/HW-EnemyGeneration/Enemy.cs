using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _pathTime;

    private Target _target;
    private Vector3 _startPosition;
    private Renderer _renderer;
    private float _currentPathRunningTime;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        _currentPathRunningTime += Time.deltaTime;
        transform.position =
            Vector3.Lerp(_startPosition, _target.transform.position, _currentPathRunningTime / _pathTime);
    }

    public void SetMotionVector(Target target)
    {
        _target = target;
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }
}