using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

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


}
