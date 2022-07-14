using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private int barrelHP = 3;
    [SerializeField] private ParticleSystem explosion;
    private static bool boom = false;

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
            barrelHP--;
            Destroy(collision.gameObject); // а надо ли? отскакивает прикольно
            if (barrelHP < 0)
            {
                barrelHP = 0;
                Instantiate(explosion, transform.position, Quaternion.identity);
                boom = true;
                // sound
                Destroy(gameObject);
            }
        }
    }

    static void OnTriggerEnter(Collider other)
    {
        // не работает!!!, пока не придумал как реализовать урон от взрыва
        if (boom == true)
        {
            if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
            {
                // а надо ли здесь делать массив объектов?..
                // здесь лучше обращаться к скриптам здоровья, которых пока нет
                Destroy(other.gameObject);
            }
        }
    }
}
