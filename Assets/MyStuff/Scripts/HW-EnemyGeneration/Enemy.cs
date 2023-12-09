using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4f;

    private void Update()
    {
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
}