using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    [SerializeField] private float plusHP = 20f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            //Debug.Log($"{collision.gameObject.name} has health script");
            player.GetComponent<HealthManager>().AddHealth(plusHP);
            Destroy(gameObject);
        }
    }
}
