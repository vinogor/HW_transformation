using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private Color _color;

    private Target _target;

    private void Start()
    {
        _target = GetComponentInChildren<Target>();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = _color;
    }

    public void GenerateEnemy()
    {
        Enemy newEnemy = Instantiate(_template, transform.position, Quaternion.identity);
        newEnemy.SetMotionVector(_target);
        newEnemy.SetColor(_color);
    }
}