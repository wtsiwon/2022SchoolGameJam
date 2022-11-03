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
        Invoke(nameof(SpawnEnemy), 5);
        Invoke(nameof(SpawnEnemy), 20);
    }

    private void SpawnEnemy()
    {
        StartCoroutine(CSpawnEnemy());
    }

    private IEnumerator CSpawnEnemy()
    {
        while (true)
        {
            if (isSpawn)
            {
                SpawnBasicEnemy();
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

    private Enemy SpawnBasicEnemy()
    {
        int randEnemy = Random.Range(0, 2);
        int randPos = Random.Range(0, spawnPos.Length);
        Enemy enemy = Instantiate(enemys[randEnemy], spawnPos[randPos].position, Quaternion.identity);
        return enemy;
    }

    private Enemy SpawnMiddleEnemy()
    {
        int randPos = Random.Range(0, spawnPos.Length);
        Enemy enemy = Instantiate(enemys[2], spawnPos[randPos].position, Quaternion.identity);

        return enemy;
    }

    private Enemy SpawnBossEnemy()
    {
        int randPos = Random.Range(0, spawnPos.Length);
        Enemy enemy = Instantiate(enemys[3], spawnPos[randPos].position, Quaternion.identity);
        return enemy;
    }

    private void Wave(int basicEnemyNum = 0, int middleNum = 0, int bossNum = 0)
    {
        for (int i = 0; i < basicEnemyNum; i++)
        {
            SpawnBasicEnemy();
        }

        for (int i = 0; i < middleNum; i++)
        {
            SpawnMiddleEnemy();
        }

        for (int i = 0; i < bossNum; i++)
        {
            SpawnBossEnemy();
        }
    }

}
