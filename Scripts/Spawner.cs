using System.Collections;
using UnityEngine;

public class Spawner : PoolObject
{
    [SerializeField] private GameObject[] _spawnedObject;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spwnPoints;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());

        Initialized(_spawnedObject);
    }

    private IEnumerator SpawnEnemy()
    {
        var waitForSeconds = new WaitForSeconds(_secondsBetweenSpawn);
        bool isWork = true;

        while (isWork)
        {
            if (TryGetObject(out GameObject enemy))
            {
                int indexSpawnPoint = Random.Range(0, _spwnPoints.Length);

                SetEnemy(enemy, _spwnPoints[indexSpawnPoint].position);
            }

            yield return waitForSeconds;
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }
}
