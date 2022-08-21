using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private float explosionDamage;
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionTime = 2f;
    [SerializeField] private AudioClip explosionSound;
    
    private List<GameObject> gameObjects = new List<GameObject>();

    public void Boom ()
    {
        var exp = Instantiate(explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        ExplosionDamage(explosionDamage);
        Destroy(exp, explosionTime);
        Destroy(gameObject);
    }

    private void ExplosionDamage (float damage)
    {
        foreach (var obj in gameObjects)
        {
            Vector3 explosionVector = obj.transform.position - transform.position; // находим направление от мины до объекта

            if (obj.TryGetComponent(out HealthManager health))
            {
                health.Hit(damage);
            }

            obj.GetComponent<Rigidbody>().AddForce(explosionVector * explosionForce, ForceMode.Impulse); // добавляем объекту силу по направлению вектора
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            foreach (var obj in gameObjects)
            {
                if (obj.name == other.name || other.tag == "Bullet")
                    return;
            }
            gameObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObjects.Remove(other.gameObject);
    }



}
