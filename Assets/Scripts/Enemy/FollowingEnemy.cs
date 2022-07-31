using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class FollowingEnemy : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    private NavMeshAgent agent;
    private Transform player;
    private bool isFollowing = false;
    private int index;

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
        agent.SetDestination(waypoints[0].position);
    }

    private void Update()
    {
        if (NavMesh.SamplePosition(agent.transform.position, out NavMeshHit hit, 1f, NavMesh.AllAreas))
        {
            if (NavMesh.GetAreaCost((int)Mathf.Log(hit.mask, 2)) >= 4)
                agent.speed = 1.5f;
            else
                agent.speed = 3;
        }
    }

    private void FixedUpdate()
    {
        if (isFollowing)
            Follow();
        else
            Patrol();
    }

    private void Patrol ()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            index = (index + 1) % waypoints.Length;
            agent.SetDestination(waypoints[index].position);
        }
    }

    private void Follow()
    {
        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            isFollowing = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isFollowing =false;
    }
}
