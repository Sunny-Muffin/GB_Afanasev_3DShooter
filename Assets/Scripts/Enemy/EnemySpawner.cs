using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnStep = 1f;
    //[SerializeField] private int enemyCount = 20;
    //private const float LifeTime = .5f;

    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            var enemy = Instantiate(enemyPrefab, transform);
            nextSpawnTime = Time.time + spawnStep;
            //Destroy(enemy.gameObject, LifeTime);
            //enemyCount--;
        }
    }
}
