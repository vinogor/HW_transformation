using UnityEngine;

public class SpawnsPool : MonoBehaviour
{
    [SerializeField] private float _enemyCreationTime;

    private Spawn[] _spawns;
    private float _currentRunningTime;

    private void Awake()
    {
        _spawns = GetComponentsInChildren<Spawn>();
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
        Spawn randomSpawn = _spawns[randomSpawnIndex];

        randomSpawn.GenerateEnemy();
    }
}