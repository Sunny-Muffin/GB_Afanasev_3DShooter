using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    [SerializeField] private int enemyHP = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            enemyHP--;
            Destroy(collision.gameObject); // а надо ли? отскакивает прикольно
            if (enemyHP < 0)
            {
                enemyHP = 0;
                Destroy(gameObject);
                EnemyCounterScript.EnemyKilled();
                // particle system
                // sound
            }
        }
    }
}
