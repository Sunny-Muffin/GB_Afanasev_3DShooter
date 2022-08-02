using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnStep = 1f;


    private float nextSpawnTime;

    private void Update()
    {
        int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // такое себе решение
        if (Time.time > nextSpawnTime && enemyCount < 5)
        {
            var enemy = Instantiate(enemyPrefab, transform);
            nextSpawnTime = Time.time + spawnStep;
        }
    }
}
