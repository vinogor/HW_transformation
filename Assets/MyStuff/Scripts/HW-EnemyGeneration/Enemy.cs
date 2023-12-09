using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 2f;
    private Vector3 _vector;

    public void SetMotionVector(Vector3 vector)
    {
        _vector = vector;
    }

    private void Update()
    {
        transform.Translate(_vector * (_speed * Time.deltaTime));
    }
}