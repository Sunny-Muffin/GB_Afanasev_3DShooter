using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float curHealth;
    [SerializeField] private float deathTime;

    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Scrollbar scrollbar;

    private void Awake()
    {
        curHealth = maxHealth;
        if (scrollbar)
        {
            scrollbar.size = curHealth / maxHealth;
        }
    }

    public void Hit(float damage)
    {
        curHealth -= damage;
        if (scrollbar)
        {
            scrollbar.size = curHealth / maxHealth;
        }
        if (curHealth <= 0)
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
            // death menu
        }
        else if(TryGetComponent<ExplosionScript>(out ExplosionScript exp))
        {
            exp.Boom();
        }
        else
        {
            if (gameObject.tag == "Turret")
            {
                EnemyCounterScript.EnemyKilled();
            }
            Destroy(gameObject);
        }
            
    }

    public void AddHealth(float plusHP)
    {
        curHealth += plusHP;
    }
}
