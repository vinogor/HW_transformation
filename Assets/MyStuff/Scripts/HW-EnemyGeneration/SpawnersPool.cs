using UnityEngine;

public class SpawnersPool : MonoBehaviour
{
    [SerializeField] private float _enemyCreationTime;

    private Spawner[] _spawns;
    private float _currentRunningTime;

    private void Awake()
    {
        _spawns = GetComponentsInChildren<Spawner>();
    }

    private void Update()
    {
        _currentRunningTime += Time.deltaTime;

        if (_currentRunningTime < _enemyCreationTime)
        {
            return;
        }

        _currentRunningTime = 0;

        int randomSpawnIndex = Random.Range(0, _spawns.Length);
        Spawner randomSpawner = _spawns[randomSpawnIndex];

        randomSpawner.GenerateEnemy();
    }
}