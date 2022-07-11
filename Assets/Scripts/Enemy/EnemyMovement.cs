using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    //[SerializeField] private float gravity = -20f;
    //[SerializeField] private float fireCoolDown = 0.5f;
    //[SerializeField] private float fireCoolDown = -20f;

    private Vector3 direction;
    private float step;
    private GameObject player;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    private void Update()
    {
        step = speed * Time.deltaTime;
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        //Shoot();
    }

    /*
    private void Shoot()
    {
        if (Time.time > nextSpawnTime)
        {
            var enemy = Instantiate(enemyPrefab, transform);
            nextSpawnTime = Time.time + spawnStep;
            Destroy(enemy.gameObject, LifeTime);
        }
    }
    */
}
