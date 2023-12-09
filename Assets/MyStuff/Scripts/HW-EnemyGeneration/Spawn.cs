using UnityEngine;

public class Spawn : MonoBehaviour
{
    // как сделать чтобы шаблон не был на сцене?
    [SerializeField] private Enemy _template;

    public void GenerateEnemy()
    {
        Quaternion randomRotation = Random.rotation;
        Instantiate(_template, transform.position, randomRotation);
    }
}