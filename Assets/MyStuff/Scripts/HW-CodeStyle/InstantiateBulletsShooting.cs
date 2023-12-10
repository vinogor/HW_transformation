using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _bulletVelocity;
    [SerializeField] private float _timeWaitShooting;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            Vector3 position = transform.position;
            Vector3 direction = (_objectToShoot.position - position).normalized;
            GameObject newBullet = Instantiate(_prefabBullet, position + direction, Quaternion.identity);

            Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
            rigidbody.transform.up = direction;
            rigidbody.velocity = direction * _bulletVelocity;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}