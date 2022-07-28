using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class FollowingEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    private void Update()
    {
        agent.SetDestination(player.position);
    }
}
