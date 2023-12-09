using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Enemy _template;

    public void GenerateEnemy()
    {
        Enemy newEnemy = Instantiate(_template, transform.position, Quaternion.identity);

        int minInclusive = 0;
        var maxExclusive = 10;
        Vector3 randomVector = new Vector3(
            Random.Range(minInclusive, maxExclusive),
            Random.Range(minInclusive, maxExclusive),
            Random.Range(minInclusive, maxExclusive)
        );
        newEnemy.SetMotionVector(randomVector);
    }
}