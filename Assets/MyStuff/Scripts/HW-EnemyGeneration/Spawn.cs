using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    public void GenerateEnemy()
    {
        Quaternion randomRotation = Random.rotation;
        Instantiate(_template, transform.position, randomRotation);
    }
}