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


    private void Start()
    {

    }
    public void Boom ()
    {
        var exp = Instantiate(explosion, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        ExplosionDamage(explosionDamage);
        Destroy(gameObject);
        Destroy(exp, explosionTime);
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

            if (obj.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.AddForce(explosionVector * explosionForce, ForceMode.Impulse); // добавляем объекту силу по направлению вектора
            }

        }
        //Debug.Log("BOOOM!!");
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var obj in gameObjects)
        {
            if (obj.name == other.name)
                return;
        }
        gameObjects.Add(other.gameObject);
        //Debug.Log($"{other.gameObject.name} added to list");
        
    }

    private void OnTriggerExit(Collider other)
    {
        gameObjects.Remove(other.gameObject);
        //Debug.Log($"{other.gameObject.name} removed from list");
    }
}
