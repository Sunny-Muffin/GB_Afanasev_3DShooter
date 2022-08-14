using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;
    [SerializeField] private float deathTime;

    [SerializeField] private GameObject explosionPrefab;

    private void Awake()
    {
        curHealth = maxHealth;
    }

    public void Hit(float damage)
    {
        curHealth -= damage;
        if(curHealth <= 0)
        { 
            curHealth = 0;
            // make coroutine
            Death();
        }

    }

    private void Death()
    {
        // sound
        // animation
        // wait
        if (gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            // menu
        }
        else if(TryGetComponent<ExplosionScript>(out ExplosionScript exp))
        {
            exp.Boom();
        }
        else
            Destroy(gameObject);
    }

    public void AddHealth(float plusHP)
    {
        curHealth += plusHP;
    }
}
