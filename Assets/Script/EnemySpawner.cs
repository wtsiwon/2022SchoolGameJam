using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public Enemy[] enemys;

    public Transform[] spawnPos;

    public float spawnDel;

    public float spawnInterval;

    public bool isSpawn;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(CSpawnEnemy());
    }

    private IEnumerator CSpawnEnemy()
    {
        while (true)
        {
            if (isSpawn)
            {
                SpawnRandomEnemy();
            }
            yield return new WaitForSeconds(spawnDel +
                Random.Range(-spawnInterval, spawnInterval));

        }
    }

    private Enemy SpawnRandomEnemy()
    {
        int randEnemy = Random.Range(0, enemys.Length);
        int randPos = Random.Range(0, spawnPos.Length);

        Enemy enemy = Instantiate(enemys[randEnemy], spawnPos[randPos].position, Quaternion.identity);

        return enemy;
    }

}
